using FluentValidation;

namespace HepsiBuradaApi.Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(2)
            .WithName("İsim Soyisim");

        RuleFor(x => x.Mail)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(6)
            .WithName("Şifre");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(50)
            .MinimumLength(6)
            .Equal(x => x.Password)
            .WithName("Şifre Tekrarı");
    }
}
