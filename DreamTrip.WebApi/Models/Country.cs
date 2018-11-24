using Microsoft.EntityFrameworkCore;

namespace DreamTrip.WebApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}