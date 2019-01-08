using System.Collections.Generic;

namespace DreamTrip.WebApi.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}