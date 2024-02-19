namespace BarManagment.Application.Core.Abstractions.Cryptography
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
