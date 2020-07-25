using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Cardiologue
    {
        //[Key]
        public int CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Qualificaction { get; set; }

        //public string Username { get; set; }
        //[ForeignKey("Username")]
        public Compte Compte { get; set; }
        public List<InterventionMedicale> InterventionMedicales { get; set; }
    }
}
