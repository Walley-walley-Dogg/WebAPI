using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BookingsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Booking> GetBookings()
        {
            return context.Bookings.OrderByDescending(c => c.Id).ToList();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var booking = context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }
        [HttpPost]
        public IActionResult CreateBooking(BookingDto bookingDto)
        {

            var client  = context.Clients.FirstOrDefault(x=>x.Id==bookingDto.ClientId);
            var tour  = context.Tours.FirstOrDefault(x=>x.Id == bookingDto.TourId);

            if(client == null)
            {
                ModelState.AddModelError("Id", "This Client doesnt exist!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            if(tour == null)
            {
                ModelState.AddModelError("Id", "This Tour doesnt exist!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var booking = new Booking
            {
               ClientId = bookingDto.ClientId,
               TourId = bookingDto.TourId,
               BookingDate = bookingDto.BookingDate,
               NumberOfPeople = bookingDto.NumberOfPeople,

            };

            context.Bookings.Add(booking);
            context.SaveChanges();

            return Ok(booking);
        }
        [HttpPut("{id}")]
        public IActionResult EditBooking(int id, BookingDto bookingDto)
        {

            var client = context.Clients.FirstOrDefault(x => x.Id == bookingDto.ClientId);
            var tour = context.Tours.FirstOrDefault(x => x.Id == bookingDto.TourId);

            if (client == null)
            {
                ModelState.AddModelError("Id", "This Client doesnt exist!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            if (tour == null)
            {
                ModelState.AddModelError("Id", "This Tour doesnt exist!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var booking = context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            booking.BookingDate = bookingDto.BookingDate;
            booking.NumberOfPeople = bookingDto.NumberOfPeople;
            booking.TourId = bookingDto.TourId;
            booking.ClientId = bookingDto.ClientId;

            context.SaveChanges();

            return Ok(booking);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = context.Bookings.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            context.Bookings.Remove(booking);
            context.SaveChanges();

            return Ok();
        }
    }
}
