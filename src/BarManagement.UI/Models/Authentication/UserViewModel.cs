using BarManagement.UI.Models.Schedule;

namespace BarManagement.UI.Models.Authentication
{
    public class UserViewModel
    {
        public Guid Id {  get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<GetScheduleViewModel>  Schedules {  get; set; }
    }
}
