using CoroCure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoroCure.Data.DTO
{
    public class CardiologueDTO
    {
        public int CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Qualification { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public CardiologueDTO(Cardiologue c)
        {
            CIN = c.CIN;
            Nom = c.Nom;
            Prenom = c.Prenom;
            Qualification = c.Qualifaction;
            Username = c.Username;
            Role = c.Compte.Role;
        }

    }

}
