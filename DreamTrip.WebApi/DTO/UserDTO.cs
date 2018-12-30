using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamTrip.WebApi.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
    }
}
