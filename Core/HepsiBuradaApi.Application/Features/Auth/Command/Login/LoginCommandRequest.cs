using System.ComponentModel;
using MediatR;

namespace HepsiBuradaApi.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    [DefaultValue("kadir@mail.com")] public string Email { get; set; }
    [DefaultValue("25019504")] public string Password { get; set; }
}
