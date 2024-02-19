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
            string passwordHash) : base(id) 
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Email = email;
            PhoneNumber = phoneNumber;
            CompanyCode = companyCode;
            Schedules = new List<BarmenSchedule>();
            _passwordHash = passwordHash;
        }

        private User() { }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public string Patronymic { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public string CompanyCode { get; private set; }

        public IEnumerable<BarmenSchedule> Schedules { get; private set; }

        public static User CreateManager(string name, string surname, string patronymic, string email, string phoneNumber, string passwordHashed)
        {
            return new User(Guid.NewGuid(), name, surname, patronymic, email, phoneNumber, Guid.NewGuid().ToString(), passwordHashed);
        }

        public bool VerifyPasswordHash(string password, IPasswordHashChecker passwordHashChecker)
            => !string.IsNullOrWhiteSpace(password) && passwordHashChecker.HashesMatch(_passwordHash, password);
    }
}