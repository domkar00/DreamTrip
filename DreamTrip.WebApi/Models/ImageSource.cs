namespace DreamTrip.WebApi.Models
{
    public class ImageSource
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public bool IsMain { get; set; }
        public Trip Trip { get; set; }
    }
}