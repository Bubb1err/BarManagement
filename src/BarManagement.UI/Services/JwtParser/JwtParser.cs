using System.IdentityModel.Tokens.Jwt;

namespace BarManagement.UI.Services.JwtParser
{
    public class JwtParser : IJwtParser
    {
        public string? GetRoleFromToken(string token)
        {
            var jwt_token = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var roleClaim = jwt_token.Claims.SingleOrDefault(c => c.Type == "role");
            return roleClaim?.Value;
        }
    }
}
