using System;
using HepsiBuradaApi.Domain.Common;

namespace HepsiBuradaApi.Domain.Entities
{
    public class Product : EntityBase
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public int BrandId { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Category> Categories { get; set; }

        //public required String ImagePath { get; set; }

    }
}

