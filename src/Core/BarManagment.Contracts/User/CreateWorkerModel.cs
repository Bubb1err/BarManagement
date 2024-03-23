namespace BarManagment.Contracts.User
{
    public sealed class CreateWorkerModel
    {
        public CreateWorkerModel(
            string name,
            string surname,
            string patronymic,
            string email,
            string phone,
            string password)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            Phone = phone;
            Password = password;
        }
        public string Name { get; }

        public string Surname { get; }

        public string Patronymic { get; }

        public string Email { get; }

        public string Phone { get; }

        public string Password { get; }
    }
}
