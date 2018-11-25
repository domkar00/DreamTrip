using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.WebApi.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool IsPromoted { get; set; }
        public DbSet<ImageSource> ImageSources { get; set; }

        public Agency Agency { get; set; }
        public int AgencyId { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }
    }
}