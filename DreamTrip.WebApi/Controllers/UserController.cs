using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamTrip.WebApi.Models;
using DreamTrip.WebApi.Services;

namespace DreamTrip.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly DatabaseContext _context;
        private IEmailService _emailService;

        public UserController(DatabaseContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        
        // GET: api/User
        [HttpPost("login")]
        public IActionResult GetUser([FromBody] User user)
        {
            var obtainedUser = _context.Users.SingleOrDefault(x => x.UserName.Equals(user.UserName) 
                                                                   && x.Password.Equals(user.Password));
            if(obtainedUser == null)
                return BadRequest();
            return Ok(obtainedUser);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            if (_context.Users.FirstOrDefault(x => (x.UserName.Equals(user.UserName) || x.Email.Equals(user.Email))) != null)
            {
                return BadRequest();
            }
            user.Id = Guid.NewGuid();
            user.UserTypeId = 1;
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser([FromRoute] Guid id, [FromBody] User user)
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
            }

            return NoContent();
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
        
    }
}