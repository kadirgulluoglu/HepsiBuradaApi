using FluentValidation;
using HepsiBuradaApi.Application.Features.Products.Command.CreateProduct;

namespace HepsiBuradaApi.Application.Features.Auth.Command.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithName("EPosta");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithName("Şifre");
    }
}
