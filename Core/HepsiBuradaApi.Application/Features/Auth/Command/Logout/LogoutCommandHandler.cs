using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Features.Auth.Command.Login;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HepsiBuradaApi.Application.Features.Auth.Command.Logout;

public class LogoutCommandHandler : BaseHandler, IRequestHandler<LogoutCommandRequest>
{
    private readonly UserManager<User> _userManager;

    public LogoutCommandHandler(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
    {
        _userManager = userManager;
    }

    public async Task Handle(LogoutCommandRequest request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByIdAsync(userId);
        user.RefreshToken = null;
        user.RefreshTokenExpiryTime = null;
    }
}
