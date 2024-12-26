using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ClientDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Phone]
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
