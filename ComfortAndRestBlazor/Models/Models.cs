namespace ComfortAndRestBlazor.Models
{
    public class Models
    {
        public class Country
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";

        }

        public class Client
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = "";
            public string LastName { get; set; } = "";
            public string Email { get; set; } = "";
            public string Phone { get; set; } = "";
            public string Address { get; set; } = "";
            
        }

        public class Tour
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public string Description { get; set; } = "";
            public decimal Price { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int CountryId { get; set; }
            
           
        }

        public class Booking
        {
            public int Id { get; set; }
            public int ClientId { get; set; }
            public int TourId { get; set; }
            public DateTime BookingDate { get; set; }
            public int NumberOfPeople { get; set; }
            
            
        }
    }
}
