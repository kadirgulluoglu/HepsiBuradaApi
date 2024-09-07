using System;
using HepsiBuradaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiBuradaApi.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Product product = new()
            {
                Id = 1,
                BrandId = 1,
                Title = "Macbook Air",
                Description = "M2",
                Price = 25000,
                Discount = 10,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };
            Product product2 = new()
            {
                Id = 2,
                BrandId = 1,
                Title = "Macbook Pro",
                Description = "M2",
                Price = 40000,
                Discount = 20,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };
            Product product3 = new()
            {
                Id = 3,
                BrandId = 2,
                Title = "Kot Pantolon",
                Description = "",
                Price = 40000,
                Discount = 20,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };

            Product product4 = new()
            {
                Id = 4,
                BrandId = 3,
                Title = "Lenova x5",
                Description = "",
                Price = 3000,
                Discount = 20,
                CreatedDate = DateTime.UtcNow,
                IsDeleted = false,
            };


            builder.HasData(product, product2, product3, product4);
        }
    }
}
