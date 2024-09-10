using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Features.Auth.Exceptions;
using HepsiBuradaApi.Application.Features.Products.Exception;
using HepsiBuradaApi.Domain.Entities;

namespace HepsiBuradaApi.Application.Features.Auth.Rules;

public class AuthRules : BaseRules
{
    public Task UserShouldNotBeExist(User? user)
    {
        if (user is not null) throw new UserAlreadyExistException();

        return Task.CompletedTask;
    }

    public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
    {
        if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
        return Task.CompletedTask;
    }

    public Task RefreshTokenShouldBeNotExpired(DateTime? refreshTokenExpirationDate)
    {
        if (refreshTokenExpirationDate <= DateTime.Now) throw new RefreshTokenShouldBeNotExpiredException();
        return Task.CompletedTask;
    }
}
