using System;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Domain.Entities;
using MediatR;

namespace HepsiBuradaApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>()
                  .GetAsync(x => x.Id == request.Id && !x.IsDeleted);


            var map = mapper.Map<Product, UpdateProductCommandRequest>(request);

            // 1. Mevcut kategorileri al
            var existingCategories = (await unitOfWork.GetReadRepository<ProductCategory>()
                .GetAllAsync(x => x.ProductId == product.Id)).Select(p => p.
                CategoryId).ToHashSet();

            // 2. Yeni kategorileri belirle
            var newCategoryIds = request.CategoryIds.ToHashSet();

            // 3. Silinmesi gereken kategorileri bul
            HashSet<int> removedCategory = new(existingCategories);
            removedCategory.ExceptWith(newCategoryIds);


            // 4. Eklenmesi gereken yeni kategorileri bul
            HashSet<int> addedCategory = new(newCategoryIds);
            addedCategory.ExceptWith(existingCategories);

            // 5. Silme işlemini gerçekleştir
            if (removedCategory.Any())
            {
                List<ProductCategory>? list = fillProductCategoryWithId(removedCategory, product.Id);
                await unitOfWork.GetWriteRepository<ProductCategory>()
                  .HardDeleteRangeAsync(list);
            }

            // 6. Ekleme işlemini gerçekleştir

            if (addedCategory.Any()) {
                List<ProductCategory>? list = fillProductCategoryWithId(addedCategory, product.Id);
            }


            foreach (var categoryId in addedCategory)
            {
                await unitOfWork.GetWriteRepository<ProductCategory>()
                    .AddAsync(new ProductCategory
                    {
                        CategoryId = categoryId,
                        ProductId = product.Id,
                    });
            }

            // 7. Ürünü güncelle
            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);

            // 8. Değişiklikleri kaydet
            await unitOfWork.SaveAsync();

            return Unit.Value;

        }

        List<ProductCategory> fillProductCategoryWithId(HashSet<int> categories, int productId)
        {
            List<ProductCategory> list = new();
            foreach (int item in categories)
            {
                list.Add(new ProductCategory()
                {
                    CategoryId = item,
                    ProductId = productId,
                });
            }

            return list;
        }

    }

}

