using HepsiBuradaApi.Application.Features.Auth.Command.Login;
using MediatR;

namespace HepsiBuradaApi.Application.Features.Auth.Command.Logout;

public class LogoutCommandRequest : IRequest<LogoutCommandResponse> { }
