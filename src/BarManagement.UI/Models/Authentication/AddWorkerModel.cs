using System.ComponentModel.DataAnnotations;

namespace BarManagement.UI.Models.Authentication
{
    public class AddWorkerModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Patronymic { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Phone]
        [Required]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public string? AdminId { get; set; } = string.Empty;
    }
}
