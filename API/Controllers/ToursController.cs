using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public ToursController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public List<Tour> GetTours()
        {
            return context.Tours.OrderByDescending(c=>c.Id).ToList();
        }
        [HttpGet("{id}")]
        public IActionResult GetTour(int id)
        {
            var tour = context.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour);
        }
        [HttpPost]
        public IActionResult CreateTour(TourDto tourDto)
        {

            var otherTour = context.Tours.FirstOrDefault(c => c.Name == tourDto.Name);
            if (otherTour != null)
            {
                ModelState.AddModelError("Name", "The Name was used!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var otherCountry = context.Countries.FirstOrDefault(c=>c.Id==tourDto.CountryId);
            if (otherCountry == null)
            {
                ModelState.AddModelError("Id", "This country doesnt exist!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var tour = new Tour
            {
                Name = tourDto.Name,
                Description = tourDto.Description,
                Price = tourDto.Price,
                StartDate = tourDto.StartDate,
                EndDate = tourDto.EndDate,
                CountryId = tourDto.CountryId,

            };

            context.Tours.Add(tour);
            context.SaveChanges();

            return Ok(tour);
        }
        [HttpPut("{id}")]
        public IActionResult EditTour(int id, TourDto tourDto)
        {
            var otherTour = context.Tours.FirstOrDefault(c => c.Id != id && c.Name == tourDto.Name);
            if (otherTour != null)
            {
                ModelState.AddModelError("Name", "The Name is already used!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var otherCountry = context.Countries.FirstOrDefault(c => c.Id == tourDto.CountryId);
            if (otherCountry == null)
            {
                ModelState.AddModelError("Id", "This country doesnt exist!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var tour = context.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }
            tour.Name = tourDto.Name;
            tour.Description = tourDto.Description;
            tour.Price = tourDto.Price;
            tour.StartDate = tourDto.StartDate;
            tour.EndDate = tourDto.EndDate;
            tour.CountryId = tourDto.CountryId;

            context.SaveChanges();

            return Ok(tour);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTour(int id)
        {
            var tour = context.Tours.Find(id);
            if (tour == null)
            {
                return NotFound();
            }
            context.Tours.Remove(tour);
            context.SaveChanges();

            return Ok();
        }

    }
}

