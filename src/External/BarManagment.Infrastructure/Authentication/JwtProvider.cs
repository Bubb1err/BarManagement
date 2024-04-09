using BarManagment.Application.Core.Abstractions.Authentication;
using BarManagment.Domain.DomainEntities;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using BarManagment.Infrastructure.Authentication.Settings;
using BarManagment.Application.Core.Abstractions.Common;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BarManagment.Infrastructure.Authentication
{
    internal class JwtProvider : IJwtProvider
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTime _dateTime;

        public JwtProvider(
            IOptions<JwtSettings> jwtOptions,
            IDateTime dateTime)
        {
            _jwtSettings = jwtOptions.Value;
            _dateTime = dateTime;
        }
        public string Create(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
            {
                new Claim("userId", user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("name", user.Name),
                new Claim("role", user.Role.Title.ToString())
            };

            DateTime tokenExpirationTime = _dateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes);

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                null,
                tokenExpirationTime,
                signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
