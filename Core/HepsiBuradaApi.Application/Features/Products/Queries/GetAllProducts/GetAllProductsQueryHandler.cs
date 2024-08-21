﻿using System;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Domain.Entities;
using MediatR;

namespace HepsiBuradaApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            List<GetAllProductsQueryResponse> response = new();

            foreach (var product in products)
            {
                response.Add(
                    new GetAllProductsQueryResponse()
                    {
                        id= product.Id,
                        Title = product.Title,
                        Description = product.Description,
                        Discount = product.Discount,
                        Price = product.Price,
                    }
                    );
            }

            return response;

        }
    }
}

