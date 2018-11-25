using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamTrip.WebApi.Models;

namespace DreamTrip.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageSourceController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ImageSourceController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ImageSource/5
        [HttpGet("{id}")]
        public IEnumerable<ImageSource> GetImageSource([FromRoute] int id)
        {
            return _context.ImageSources.Where(e => e.TripId == id);
        }

        // PUT: api/ImageSource/5
        [HttpPut("{id}")]
        public IActionResult PutImageSource([FromRoute] int id, [FromBody] ImageSource imageSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageSource.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageSource).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageSourceExists(id))
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

        // POST: api/ImageSource
        [HttpPost]
        public IActionResult PostImageSource([FromBody] ImageSource imageSource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ImageSources.Add(imageSource);
            _context.SaveChanges();

            return CreatedAtAction("GetImageSource", new { id = imageSource.Id }, imageSource);
        }

        // DELETE: api/ImageSource/5
        [HttpDelete("{id}")]
        public IActionResult DeleteImageSource([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageSource = _context.ImageSources.Find(id);
            if (imageSource == null)
            {
                return NotFound();
            }

            _context.ImageSources.Remove(imageSource);
            _context.SaveChanges();

            return Ok(imageSource);
        }

        private bool ImageSourceExists(int id)
        {
            return _context.ImageSources.Any(e => e.Id == id);
        }
    }
}