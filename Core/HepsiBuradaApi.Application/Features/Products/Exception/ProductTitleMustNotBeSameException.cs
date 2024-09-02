using System;
using HepsiBuradaApi.Application.Bases;

namespace HepsiBuradaApi.Application.Features.Products.Exception
{
    public class ProductTitleMustNotBeSameException : BaseExceptions
    {
        public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var!") { }
    }
}

