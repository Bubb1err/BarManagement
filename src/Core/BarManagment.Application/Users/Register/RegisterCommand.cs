using BarManagment.Contracts.Authentication;
using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BarManagment.Application.Users.Register
{
    public class RegisterCommand : IRequest<TokenResponse>
    {
        public RegisterCommand(
            string name, 
            string surname,
            string patronymic,
            string email, 
            string phoneNumber, 
            string password,
            string passwordConfirm)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        [Required]
        [EmailAddress]
        public string Email { get; }
        [Required]
        [Phone]
        public string PhoneNumber { get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; }
    }
}
