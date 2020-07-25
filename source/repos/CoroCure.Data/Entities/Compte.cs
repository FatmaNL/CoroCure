using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Compte
    {
        //[Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int CIN { get; set; }
        //[ForeignKey("cin")]
        public Cardiologue Cardiologue { get; set; }

    }
}
