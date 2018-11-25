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
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }
        
        // GET: api/User
        [HttpGet("{{username}/{password}}")]
        public bool GetUser([FromRoute] User user)
        {
            return _context.Users.Any(e => e.UserName.Equals(user.UserName) && e.Password.Equals(user.Password));
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser([FromRoute] int id, [FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}