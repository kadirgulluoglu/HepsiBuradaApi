using System;
namespace HepsiBuradaApi.Infrastructure.Tokens
{
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMunitues { get; set; }
        public int RefreshTokenValidityInMunitues { get; set; }

        public TokenSettings()
        {
        }
    }
}

