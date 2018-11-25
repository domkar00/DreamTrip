using System.ComponentModel.DataAnnotations;
using DreamTrip.WebApi.Enums;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.WebApi.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        public UserType UserType => (UserType) UserTypeId;
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}