namespace BarManagement.UI.Models.Authentication
{
    public class WorkerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CompanyCode { get; set; }

        public Guid RoleId { get; private set; }
    }
}
