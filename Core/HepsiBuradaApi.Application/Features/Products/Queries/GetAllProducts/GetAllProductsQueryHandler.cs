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
                    include: x => x.Include(b => b.Brand).Include(c => c.ProductCategories),
                    pageIndex: request.PageIndex,
                    pageSize: request.PageSize
                );

            foreach (var item in products)
            {
                item.Price -= (item.Price * item.Discount / 100);
            }

            var brand = mapper.Map<BrandDto, Brand>(new Brand());

            var map = mapper.Map<ProductDto, Product>(products);


            return new()
            {
                Product = map,
                TotalCount = map.Count()
            };
        }
    }
}
