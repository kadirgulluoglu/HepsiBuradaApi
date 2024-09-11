using HepsiBuradaApi.Application.Bases;

namespace HepsiBuradaApi.Application.Features.Auth.Exceptions;

public class RefreshTokenShouldBeNotExpiredException : BaseException
{
    public RefreshTokenShouldBeNotExpiredException() : base("Oturum süresi dolmuştur. Lütfen tekrar giriş yapınız") { }
}
