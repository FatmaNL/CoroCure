using System;
using System.Collections.Generic;
using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string NSS { get; set; }
        public string Adresse { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Sexe { get; set; }
        public List<InterventionMedicaleDTO> InterventionMedicales { get; set; }
    }
}