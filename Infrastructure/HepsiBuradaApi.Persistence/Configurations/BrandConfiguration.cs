using System;
using HepsiBuradaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiBuradaApi.Persistence.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public BrandConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);

            Brand brand = new()
            {
                Id = 1,
                Name = "Apple",
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };
            Brand brand2 = new()
            {
                Id = 2,
                Name = "Mavi",
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };


            Brand brand3 = new()
            {
                Id = 3,
                Name = "Lenova",
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };


            builder.HasData(brand, brand2, brand3);
        }
    }
}
