using System;
using System.Collections.Generic;
using DreamTrip.Desktop.Enums;

namespace DreamTrip.WebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType => (UserType) UserTypeId;
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }

        public bool IsVerified { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}