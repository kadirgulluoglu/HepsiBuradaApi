using HepsiBuradaApi.Application.Bases;

namespace HepsiBuradaApi.Application.Features.Auth.Exceptions;

public class UserAlreadyExistException : BaseException
{
    public UserAlreadyExistException() : base("Böyle bir Kullanıcı zaten var!")
    {
    }
}
