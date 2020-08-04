using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Integration.BLL.Contracts;
using Integration.BLL.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Integration.BLL
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IOptionsMonitor<BLLOptions> _options;

        public JwtTokenService(IOptionsMonitor<BLLOptions> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public string GenerateToken()
        {
            var nowDT = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.CurrentValue.JwtSecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                NotBefore = nowDT,
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("dt", nowDT.ToString("yyyy-MM-ddTHH:mm:ssK"))
                }),
                Expires = nowDT.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var finalToken = tokenHandler.WriteToken(token);

            return finalToken;
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.CurrentValue.JwtSecretKey))
            };

            try
            {
                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
