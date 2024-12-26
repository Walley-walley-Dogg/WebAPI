using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class TourDto
    {
        [Required(ErrorMessage ="Tour name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tour description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Country ID is required")]
        public int CountryId { get; set; }
      
    }
}
