using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string NSS { get; set; }
        public string Adresse { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Sexe { get; set; }
        public List<InterventionMedicale> InterventionMedicales { get; set; }
    }
}
