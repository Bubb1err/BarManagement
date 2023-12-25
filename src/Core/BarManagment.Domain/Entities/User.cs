
namespace BarManagment.Domain.Entities
{
    public sealed class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }//identity user
        public string Surname { get; set; }//identity user
        public string Email { get; set; }//identity user
        public string Phone { get; set; }//identity user
        public string Role { get ; set; } //identity user
    }
}
