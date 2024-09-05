using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HepsiBuradaApi.Application.Interfaces.Tokens;
using HepsiBuradaApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HepsiBuradaApi.Infrastructure.Tokens
{
    public class TokenService : IToken
    {
        private readonly TokenSettings tokenSettings;
        private readonly UserManager<User> userManager;

        public TokenService(IOptions<TokenSettings> options, UserManager<User> userManager)
        {
            tokenSettings = options.Value;
            this.userManager = userManager;
        }

        public async Task<JwtSecurityToken> CreateToken(User user, IList<Role> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),

            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));

            JwtSecurityToken? token = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(tokenSettings.TokenValidityInMunitues),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );


            await userManager.AddClaimsAsync(user, claims);
            return token;
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken()
        {
            throw new NotImplementedException();
        }
    }
}

