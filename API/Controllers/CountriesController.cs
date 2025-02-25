﻿using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CountriesController(ApplicationDbContext context) 
        { 
            this.context = context;
        }

        [HttpGet]
        public List<Country> GetCountries()
        {
            return context.Countries.OrderByDescending(c => c.Id).ToList();
        }
        [HttpGet("{id}")]
        public IActionResult GetCountry(int id)
        {
            var country = context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
        [HttpPost]
        public IActionResult CreateCountry(CountryDto countryDto)
        {

            var otherCountry = context.Countries.FirstOrDefault(c=>c.Name == countryDto.Name);
            if (otherCountry != null)
            {
                ModelState.AddModelError("Name", "The name is already used!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var country = new Country
            {
                Name = countryDto.Name,
                Description = countryDto.Description,
            };
            context.Countries.Add(country);
            context.SaveChanges();

            return Ok(country);
        }
        [HttpPut("{id}")]
        public IActionResult EditCountry(int id, CountryDto countryDto)
        {
            var otherCountry = context.Countries.FirstOrDefault(c=>c.Id!=id && c.Name == countryDto.Name);
            if (otherCountry != null)
            {
                ModelState.AddModelError("Name", "The name is already used!");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            var country = context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            country.Name = countryDto.Name;
            country.Description = countryDto.Description;
            
            context.SaveChanges();

            return Ok(country);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var country = context.Countries.Find(id);
            if (country == null)
            {
                return NotFound();
            }
            context.Countries.Remove(country);
            context.SaveChanges();

            return Ok();
        }

    }
}
