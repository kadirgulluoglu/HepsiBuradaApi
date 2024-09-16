using System;
using HepsiBuradaApi.Domain.Common;

namespace HepsiBuradaApi.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product() { }

        public Product(string title, string description, int brandId, decimal price, decimal discount,
            HashSet<ProductCategory> categoriesId)
        {
            Title = title;
            Description = description;
            BrandId = brandId;
            Price = price;
            Discount = discount;
            ProductCategories = new HashSet<ProductCategory>();
            ProductCategories = categoriesId;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }


        //public required String ImagePath { get; set; }
    }
}
