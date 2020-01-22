using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        [NotMapped]
        public string Token { get; set; }

    }
}
