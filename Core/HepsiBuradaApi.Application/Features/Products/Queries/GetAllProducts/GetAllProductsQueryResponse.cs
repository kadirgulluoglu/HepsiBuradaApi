using System;
using HepsiBuradaApi.Application.DTOs;

namespace HepsiBuradaApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public IList<ProductDto>? Product { get; set; }
        public int TotalCount { get; set; }
    }
}
