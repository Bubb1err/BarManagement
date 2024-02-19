using MediatR;

namespace BarManagment.Application.Users.Login
{
    public class LoginCommand : IRequest<string>
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
