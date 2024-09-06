using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HepsiBuradaApi.Domain.Entities;

namespace HepsiBuradaApi.Application.Interfaces.Tokens
{
    public interface IToken
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<Role> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}

