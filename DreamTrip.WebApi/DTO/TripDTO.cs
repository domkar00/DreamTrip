using System.Collections.Generic;
using DreamTrip.WebApi.Models;

namespace DreamTrip.WebApi.DTO
{
    public class TripDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool IsPromoted { get; set; }
        public IEnumerable<ImageSource> ImageSources { get; set; }
        public int AgencyId { get; set; }
        public int CityId { get; set; }
    }
}
