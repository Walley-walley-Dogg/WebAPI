using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CountryDto
    {
        [Required(ErrorMessage ="Country name is required")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = "";
  
    }
}
