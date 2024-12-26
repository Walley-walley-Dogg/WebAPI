using Microsoft.EntityFrameworkCore;
using API.Models;
namespace API.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
