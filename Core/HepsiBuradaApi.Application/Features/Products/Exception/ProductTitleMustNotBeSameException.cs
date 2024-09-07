using System;
using HepsiBuradaApi.Application.Bases;

namespace HepsiBuradaApi.Application.Features.Products.Exception
{
    public class ProductTitleMustNotBeSameException : BaseException
    {
        public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var!") { }
    }
}
