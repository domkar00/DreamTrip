using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamTrip.WebApi.Models;

namespace DreamTrip.WebApi.Controllers
{
    [Route("api/agency")]
    [Produces("application/json")]
    [ApiController]
    public class AgencyController : Controller
    {
        private readonly DatabaseContext _context;

        public AgencyController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Agencies
        [HttpGet]
        public IEnumerable<Agency> GetAgencies()
        {
            return _context.Agencies;
        }

        // GET: api/Agencies/5
        [HttpGet("{id}")]
        public IActionResult GetAgency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agency = _context.Agencies.Find(id);

            if (agency == null)
            {
                return NotFound();
            }

            return Ok(agency);
        }

        // PUT: api/Agencies/5
        [HttpPut("{id}")]
        public IActionResult PutAgency([FromRoute] int id, [FromForm] Agency agency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agency.Id)
            {
                return BadRequest();
            }

            _context.Entry(agency).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgencyExists(id))
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

        // POST: api/Agencies
        [HttpPost]
        public IActionResult PostAgency([FromForm] Agency agency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Agencies.Add(agency);
            _context.SaveChanges();

            return CreatedAtAction("GetAgency", new { id = agency.Id }, agency);
        }

        // DELETE: api/Agencies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAgency([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agency = _context.Agencies.Find(id);
            if (agency == null)
            {
                return NotFound();
            }

            _context.Agencies.Remove(agency);
            _context.SaveChanges();

            return Ok(agency);
        }

        private bool AgencyExists(int id)
        {
            return _context.Agencies.Any(e => e.Id == id);
        }
    }
}