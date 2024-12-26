using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    [Index("Name", IsUnique =true)]
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Tour> Tours { get; set; }
        
    }
    [Index("Email", IsUnique =true)]
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
    [Index("Name", IsUnique = true)]
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }

    public class Booking
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TourId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
        public Client Client { get; set; }
        public Tour Tour { get; set; }
    }
}
