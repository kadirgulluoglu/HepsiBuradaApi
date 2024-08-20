using System;
using HepsiBuradaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HepsiBuradaApi.Persistence.Configurations
{
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Detail detail = new()
            {
                Id = 1,
                Title = "Rengi",
                IsDeleted = false,
                CategoryId = 1,
                CreatedDate = DateTime.UtcNow,
                Description = "Mavi",
            };
            Detail detail2 = new()
            {
                Id = 2,
                Title = "Boyutu",
                IsDeleted = false,
                CategoryId = 1,
                CreatedDate = DateTime.UtcNow,
                Description = "15x20",
            };
            Detail detail3 = new()
            {
                Id = 3,
                Title = "Tür",
                IsDeleted = false,
                CategoryId = 5,
                CreatedDate = DateTime.UtcNow,
                Description = "Ahşap",
            };
            Detail detail4 = new()
            {
                Id = 4,
                Title = "Şekil",
                IsDeleted = false,
                CategoryId = 2,
                CreatedDate = DateTime.UtcNow,
                Description = "Kare",
            };
            builder.HasData(detail, detail2, detail3, detail4);
        }
    }
}

