using System;
using HepsiBuradaApi.Domain.Common;

namespace HepsiBuradaApi.Domain.Entities
{
    public class Product : EntityBase
    {
        public required String Title { get; set; }
        public required String Description { get; set; }
        public required int BrandId { get; set; }
        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Category> Categories { get; set; }

        //public required String ImagePath { get; set; }

    }
}

