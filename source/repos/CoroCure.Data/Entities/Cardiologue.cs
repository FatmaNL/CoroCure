using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoroCure.Data.DTO;

namespace CoroCure.Data.Entities
{
    public class Cardiologue
    {
        public Cardiologue()
        {
        }

        public Cardiologue(CardiologueDTO cardiologueDTO)
        {
            this.CIN = cardiologueDTO.CIN;
            this.Nom = cardiologueDTO.Nom;
            this.Prenom = cardiologueDTO.Prenom;
            this.Qualificaction = cardiologueDTO.Qualification;

            this.Compte = new Compte();
            this.Compte.Cardiologue = this;
            this.Compte.CIN = cardiologueDTO.CIN;
            this.Compte.Username = cardiologueDTO.Username;
            this.Compte.Password = cardiologueDTO.Password;
            this.Compte.Role = cardiologueDTO.Role;
        }

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
