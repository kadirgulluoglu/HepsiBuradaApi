using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.Features.Auth.Rules;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Application.Interfaces.Tokens;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HepsiBuradaApi.Application.Features.Auth.Command.RefreshToken;

public class RefreshTokenCommandHandler : BaseHandler,
    IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
    private readonly AuthRules _authRules;
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public RefreshTokenCommandHandler(AuthRules authRules, UserManager<User> userManager, ITokenService tokenService,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
        : base(unitOfWork, mapper, httpContextAccessor)
    {
        _authRules = authRules;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request,
        CancellationToken cancellationToken)
    {
        ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
        string email = principal.FindFirstValue(ClaimTypes.Email);

        User? user = await _userManager.FindByEmailAsync(email);

        IList<string> roles = await _userManager.GetRolesAsync(user);

        await _authRules.RefreshTokenShouldBeNotExpired(user.RefreshTokenExpiryTime);

        JwtSecurityToken newAccessToken = await _tokenService.CreateToken(user, roles);

        string newRefreshToken = _tokenService.GenerateRefreshToken();


        user.RefreshToken = newRefreshToken;
        _userManager.UpdateAsync(user);

        return new()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken,
        };
    }
}
