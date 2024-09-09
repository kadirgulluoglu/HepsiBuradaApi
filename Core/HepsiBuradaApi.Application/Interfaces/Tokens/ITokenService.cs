using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HepsiBuradaApi.Domain.Entities;

namespace HepsiBuradaApi.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
