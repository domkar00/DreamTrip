using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamTrip.WebApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DreamTrip.WebApi.Models;
using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;

namespace DreamTrip.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly DatabaseContext _context;

        public OrderController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet("history/{userId}")]
        public IEnumerable<Order> GetOrders([FromRoute] Guid userId)
        {
            return _context.Orders.Where(x => x.UserId.Equals(userId));
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult PutOrder([FromRoute] int id, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Order
        [HttpPost]
        public IActionResult PostOrder([FromForm] string trips, [FromForm] string userId)
        {
            var tripsList = JsonConvert.DeserializeObject<TripDTO[]>(trips);
            var order = new Order()
            {
                UserId = new Guid(userId),
                OrderDate  = DateTime.Now,
                TotalPrice = tripsList.Sum(x => x.Price * x.Quantity)
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            var orderDetails = tripsList.Select(x => new OrderDetail()
            {
                OrderId = order.Id,
                TripId = x.Id,
                TripPrice = x.Price,
                Quantity = x.Quantity
            }).ToList();

            _context.OrderDetails.AddRange(orderDetails);
            _context.SaveChanges();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return Ok(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}