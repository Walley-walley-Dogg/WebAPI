using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class BookingDto
    {
        [Required(ErrorMessage = "Client ID is required is required")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Tour ID is required")]
        public int TourId { get; set; }
        [Required(ErrorMessage ="Booking Date is required")]
        public DateTime BookingDate { get; set; }
        [Required(ErrorMessage = "Number of people is required")]
        public int NumberOfPeople { get; set; }

    }
}
