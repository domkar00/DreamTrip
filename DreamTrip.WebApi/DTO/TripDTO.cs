using System;
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
        public string Agency { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
