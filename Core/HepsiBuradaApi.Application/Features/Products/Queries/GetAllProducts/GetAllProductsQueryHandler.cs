using System;
using HepsiBuradaApi.Application.DTOs;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HepsiBuradaApi.Application.Features.Products.Queries.GetAllProducts
{
    public class
        GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request,
            CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>()
                .GetAllByPagingAsync(predicate: x => !x.IsDeleted,
                    include: x =>
                        x.Include(b => b.Brand).Include(pc => pc.ProductCategories).ThenInclude(c => c.Category),
                    orderBy: x => x.OrderByDescending(p => p.CreatedDate),
                    pageIndex: request.PageIndex,
                    pageSize: request.PageSize
                );


            int totalCount = await unitOfWork.GetReadRepository<Product>()
                .CountAsync(predicate: x => !x.IsDeleted);

            foreach (var item in products)
            {
                item.Price -= (item.Price * item.Discount / 100);
            }

            var brand = mapper.Map<BrandDto, Brand>(new Brand());


            var productMap = mapper.Map<ProductDto, Product>(products);

            foreach (var productDto in productMap)
            {
                var product = products.First(p => p.Id == productDto.Id);
                productDto.Categories =
                    mapper.Map<CategoryDto, Category>(product.ProductCategories.Select(pc => pc.Category).ToList());
            }

            return new()
            {
                Product = productMap,
                TotalCount = totalCount
            };
        }
    }
}
