using System;
using System.Collections.Generic;
using CoroCure.Data.Entities;
using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class PatientDTO
    {
        public PatientDTO(Patient patient)
        {
            this.Id = patient.Id;
            this.Nom = patient.Nom;
            this.Prenom = patient.Prenom;
            this.Tel = patient.Tel;
            this.NSS = patient.NSS;
            this.Adresse = patient.Adresse;
            this.DateNaissance = patient.DateNaissance;
            this.Sexe = patient.Sexe;
        }

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