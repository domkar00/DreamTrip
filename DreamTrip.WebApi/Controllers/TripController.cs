using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DreamTrip.WebApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamTrip.WebApi.Models;

namespace DreamTrip.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : Controller
    {
        private readonly DatabaseContext _context;

        public TripController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Trip
        [HttpGet]
        public IEnumerable<TripDTO> GetTrips()
        {
            var trips = _context.Trips;
            var imageSources = _context.ImageSources;
            return trips.Select(trip => new TripDTO()
            {
                Id = trip.Id,
                Price = trip.Price,
                Header = trip.Header,
                Description = trip.Description,
                IsPromoted = trip.IsPromoted,
                ImageSources = imageSources.Where(image => image.TripId == trip.Id),
                AgencyId = trip.AgencyId,
                CityId = trip.CityId
            });
        }

        // GET: api/Trip/5
        [HttpGet("{id}")]
        public IActionResult GetTrip([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trip = _context.Trips.Find(id);
            var imageSources = _context.ImageSources.Where(image => image.TripId == id);
            var agency = _context.Agencies.SingleOrDefault(x => x.Id == trip.AgencyId);
            var city = _context.Cities.SingleOrDefault(x => x.Id == trip.CityId);
            var country = _context.Countries.SingleOrDefault(x => x.Id == city.CountryId);
            foreach (var imageSource in imageSources)
            {
                imageSource.Trip = null;
            }
            var tripDTO = new TripDTO()
            {
                Id = trip.Id,
                Price = trip.Price,
                Header = trip.Header,
                Description = trip.Description,
                IsPromoted = trip.IsPromoted,
                ImageSources = imageSources,
                AgencyId = trip.AgencyId,
                CityId = trip.CityId,
                CityName = city.Name,
                CountryId = country.Id,
                CountryName = country.Name,
                Agency = agency.Name
            };
            return Ok(tripDTO);
        }

        // PUT: api/Trip/5
        [HttpPut("{id}")]
        public IActionResult PutTrip([FromRoute] int id, [FromBody] Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trip.Id)
            {
                return BadRequest();
            }

            _context.Entry(trip).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trip
        [HttpPost]
        public IActionResult PostTrip([FromBody] Trip trip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Trips.Add(trip);
            _context.SaveChanges();

            return CreatedAtAction("GetTrip", new { id = trip.Id }, trip);
        }

        // DELETE: api/Trip/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTrip([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            _context.SaveChanges();

            return Ok(trip);
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.Id == id);
        }
    }
}