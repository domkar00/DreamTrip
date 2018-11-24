using Microsoft.EntityFrameworkCore;

namespace DreamTrip.WebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public User User { get; set; }
        public bool InCart { get; set; }
        public double TotalPrice { get; set; }
    }
}