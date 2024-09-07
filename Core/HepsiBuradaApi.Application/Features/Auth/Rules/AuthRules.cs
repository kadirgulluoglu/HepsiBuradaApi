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
}
