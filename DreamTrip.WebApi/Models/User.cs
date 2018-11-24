using DreamTrip.WebApi.Enums;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.WebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType => (UserType) UserTypeId;
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}