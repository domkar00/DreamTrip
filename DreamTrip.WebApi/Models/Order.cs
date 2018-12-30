using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.WebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool CanCancel { get; set; }
        public bool IsPaid { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}