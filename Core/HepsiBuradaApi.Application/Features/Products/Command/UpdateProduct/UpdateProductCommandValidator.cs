﻿using System;
using FluentValidation;

namespace HepsiBuradaApi.Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithName("Başlık");
            RuleFor(x => x.BrandId).NotEmpty().GreaterThan(0).WithName("Marka");
            RuleFor(x => x.Price).GreaterThan(0).WithName("Fiyat");
            RuleFor(x => x.Discount).GreaterThan(0).WithName("İndirim Oranı");
            RuleFor(x => x.CategoryIds).NotEmpty().Must(c => c.Any()).WithName("Kategoriler");
        }
    }
}
