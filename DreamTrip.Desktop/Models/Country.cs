using System.Collections.Generic;

namespace DreamTrip.WebApi.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}