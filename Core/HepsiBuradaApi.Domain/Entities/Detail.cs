using System;
using HepsiBuradaApi.Domain.Common;

namespace HepsiBuradaApi.Domain.Entities
{
    public class Detail : EntityBase

    {
        public Detail()
        {
        }

        public Detail(string title, string description, int categoryId, Category category)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
            Category = category;
        }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int CategoryId { get; set; }
        public required Category Category { get; set; }



    }
}

