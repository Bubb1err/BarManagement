using MediatR;

namespace BarManagment.Application.Users.Worker
{
    public sealed class AddWorkerCommand : IRequest
    {
        public AddWorkerCommand(
            string name,
            string surname,
            string patronymic,
            string email,
            string phone,
            string password,
            Guid adminId)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            Phone = phone;
            Password = password;
            AdminId = adminId;

        }
        public string Name { get; }

        public string Surname { get; }

        public string Patronymic { get; }

        public string Email { get; }

        public string Phone { get; }

        public string Password { get; }

        public Guid AdminId { get; }
    }
}
