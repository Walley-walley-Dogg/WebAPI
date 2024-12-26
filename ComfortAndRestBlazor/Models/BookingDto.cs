

namespace ComfortAndRestBlazor.Models
{
    public class BookingDto
    {
        public int ClientId { get; set; }
        public int TourId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
    }
}
