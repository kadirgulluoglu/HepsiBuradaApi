using System.IdentityModel.Tokens.Jwt;
using HepsiBuradaApi.Application.Bases;
using HepsiBuradaApi.Application.DTOs;
using HepsiBuradaApi.Application.Features.Auth.Rules;
using HepsiBuradaApi.Application.Interfaces;
using HepsiBuradaApi.Application.Interfaces.AutoMapper;
using HepsiBuradaApi.Application.Interfaces.Tokens;
using HepsiBuradaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace HepsiBuradaApi.Application.Features.Auth.Command.Login;

public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly AuthRules _authRules;
    private readonly RoleManager<Role> _roleManager;
    private readonly IConfiguration _configuration;

    public LoginCommandHandler(UserManager<User> userManager, ITokenService tokenService, AuthRules authRules,
        RoleManager<Role> roleManager,
        IUnitOfWork unitOfWork,
        IConfiguration configuration,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : base(
        unitOfWork, mapper, httpContextAccessor)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _authRules = authRules;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByEmailAsync(request.Email);
        bool checkPassword = user != null && await _userManager.CheckPasswordAsync(user, request.Password);

        await _authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);
        IList<string> roles = await _userManager.GetRolesAsync(user);
        JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
        string refreshToken = _tokenService.GenerateRefreshToken();

        _ = int.TryParse(_configuration["Jwt:RefreshTokenValidityInMunitues"], out int refreshTokenValidityInMunitues);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(refreshTokenValidityInMunitues);

        await _userManager.UpdateAsync(user);
        await _userManager.UpdateSecurityStampAsync(user);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", tokenValue);

        return new()
        {
            Token = tokenValue,
            Expiration = token.ValidTo,
            RefreshToken = refreshToken,
            user = mapper.Map<UserDto, User>(user)
        };
    }
}
