using System;
using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Features.Products.Exception;
using HepsiBuradaApi.Domain.Entities;

namespace HepsiBuradaApi.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(string title, string requestTitle)
        {
            if (title == requestTitle) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
