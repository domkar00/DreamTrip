namespace DreamTrip.WebApi.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Trip Trip { get; set; }
        public double TripPrice { get; set; }
        public int Quantity { get; set; }
    }
}