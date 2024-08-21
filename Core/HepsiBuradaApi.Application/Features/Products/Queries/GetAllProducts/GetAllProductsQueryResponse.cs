using System;
namespace HepsiBuradaApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public int id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}

