
namespace ComfortAndRestBlazor.Models
{
    public class TourDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CountryId { get; set; }

    }
}
