using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class User
    {
        public long UserID { get; set; }
        public long? ModuleID { get; set; } // a user can be responsible for a specific module
        public Module Module { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Boolean Status { get; set; }
        public string Salt { get; set; } // only used for password hashing, should be stored in db though!
        [NotMapped]
        public string Token { get; set; }
    }
}
