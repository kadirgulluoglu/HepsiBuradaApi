using HepsiBuradaApi.Application.DTOs;
using HepsiBuradaApi.Domain.Entities;

namespace HepsiBuradaApi.Application.Features.Auth.Command.Login;

public class LoginCommandResponse : BaseResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }

    public DateTime Expiration { get; set; }

    public UserDto user { get; set; }


    public LoginCommandResponse()
    {
        Message = "Giriş Başarılı";
    }
}
