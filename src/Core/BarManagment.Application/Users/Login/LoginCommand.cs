using BarManagment.Contracts.Authentication;
using MediatR;

namespace BarManagment.Application.Users.Login
{
    public class LoginCommand : IRequest<TokenResponse>
    {
        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;

        }
        public string Email { get; }

        public string Password { get; }
    }
}
