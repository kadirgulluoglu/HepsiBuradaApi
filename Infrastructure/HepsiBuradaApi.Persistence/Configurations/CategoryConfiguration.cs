using System;
using HepsiBuradaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiBuradaApi.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            Category category = new()
            {
                Id = 1,
                Name = "Elektronik",
                ParentId = 0,
                Priorty = 1,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };
            Category category1 = new()
            {
                Id = 2,
                Name = "Moda",
                ParentId = 0,
                Priorty = 2,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };
            Category category2 = new()
            {
                Id = 3,
                Name = "Bilgisayar",
                ParentId = 1,
                Priorty = 1,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };
            Category category3 = new()
            {
                Id = 4,
                Name = "Telefon",
                ParentId = 1,
                Priorty = 2,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };
            Category category4 = new()
            {
                Id = 5,
                Name = "Kadın",
                ParentId = 2,
                Priorty = 1,
                IsDeleted = false,
                CreatedDate = DateTime.UtcNow
            };

            builder.HasData(category, category1, category2, category3, category4);
        }
    }
}
