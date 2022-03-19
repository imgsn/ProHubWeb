using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProHub.Domain.Config;
using ProHub.Domain.Dtos.Jwt;

namespace ProHub.Domain.Services.Jwt
{
    public class JwtServices : IJwtServices
    {
        private readonly JwtConfig _jwtConfiguration;

        public JwtServices(IOptions<JwtConfig> jwtOptions)
        {
            _jwtConfiguration = jwtOptions.Value;
        }

        public TokenDto GenerateEncodedToken(string userId, string email, IEnumerable<Claim> additionalClaims = null)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, _jwtConfiguration.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(),
                    ClaimValueTypes.Integer64),
            };
            if (additionalClaims != null)
                claims = (Claim[])claims.Concat(additionalClaims);

            var jwt = new JwtSecurityToken(
                issuer: _jwtConfiguration.Issuer,
                audience: _jwtConfiguration.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_jwtConfiguration.LifeMinutes),
                signingCredentials: this.GenerateSigning(_jwtConfiguration.Secret));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenDto
            {
                Token = encodedJwt,
                ExpiryDate = DateTime.UtcNow.AddMinutes(_jwtConfiguration.LifeMinutes)
            };
        }


        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);

        private SigningCredentials GenerateSigning(string keyStr)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyStr));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }
    }
}
