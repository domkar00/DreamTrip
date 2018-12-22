using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DreamTrip.WebApi.Enums;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.WebApi.Models
{
    public class User
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        public UserType UserType => (UserType) UserTypeId;
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
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