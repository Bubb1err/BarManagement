using BarManagment.Domain.DomainEntities.Base;
using BarManagment.Domain.Services;

namespace BarManagment.Domain.DomainEntities
{
    public class User : BaseEntity
    {
        private string _passwordHash;
        private User(
            Guid id, 
            string name,
            string surname,
            string patronymic,
            string email,
            string phoneNumber, 
            string companyCode,
            string passwordHash,
            Role role) : base(id) 
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            PhoneNumber = phoneNumber;
            CompanyCode = companyCode;
            Schedules = new List<BarmenSchedule>();
            _passwordHash = passwordHash;
            Role = role;
            RoleId = role.Id;
        }

        private User() { }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Patronymic { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public string CompanyCode { get; private set; }

        public IEnumerable<BarmenSchedule> Schedules { get; private set; }

        public Guid RoleId { get; private set; }

        public Role Role { get; private set; }

        public static User CreateManager(string name, string surname, string patronymic, string email, string phoneNumber, string passwordHashed, Role role)
        {
            return new User(Guid.NewGuid(), name, surname, patronymic, email, phoneNumber, Guid.NewGuid().ToString(), passwordHashed, role);
        }

        public static User CreateWorker(string name, string surname, string patronymic, string email, string phoneNumber, string companyCode, string passwordHashed, Role role)
        {
            return new User(Guid.NewGuid(), name, surname, patronymic, email, phoneNumber, companyCode, passwordHashed, role);
        }

        public bool VerifyPasswordHash(string password, IPasswordHashChecker passwordHashChecker)
            => !string.IsNullOrWhiteSpace(password) && passwordHashChecker.HashesMatch(_passwordHash, password);
    }
}