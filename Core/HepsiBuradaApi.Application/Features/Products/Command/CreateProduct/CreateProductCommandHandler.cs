using System;
using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Features.Products.Rules;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HepsiBuradaApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : BaseHandler,
        IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly ProductRules _productRules;


        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,
            IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(unitOfWork, mapper,
            httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request,
            CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(
                predicate: x => x.Title == request.Title
            );

            if (products.Any())
            {
                await _productRules.ProductTitleMustNotBeSame(products.First().Title, request.Title);
            }


            // var map = mapper.Map<Product, CreateProductCommandRequest>(request);

            Product product = new(request.Title, request.Description, request.BrandId, request.Price,
                request.Discount);

            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (int categoryId in request.CategoriesId)
                    await unitOfWork.GetWriteRepository<ProductCategory>()
                        .AddAsync(new()
                        {
                            ProductId = product.Id,
                            CategoryId = categoryId
                        });
                await unitOfWork.SaveAsync();
            }

            return new CreateProductCommandResponse();
        }
    }
}
