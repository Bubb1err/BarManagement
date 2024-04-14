namespace BarManagement.UI.Services.JwtParser
{
    public interface IJwtParser
    {
        string? GetRoleFromToken(string token);

        string? GetIdFromToken(string token);
    }
}
