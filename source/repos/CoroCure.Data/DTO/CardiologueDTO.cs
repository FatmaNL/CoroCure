using CoroCure.Data.Entities;
using Reinforced.Typings.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoroCure.Data.DTO
{
    public class CardiologueDTO
    {
        public CardiologueDTO()
        {
        }

        public CardiologueDTO(Cardiologue c)
        {
            CIN = c.CIN;
            Nom = c.Nom;
            Prenom = c.Prenom;
            Qualification = c.Qualificaction;
            Username = c.Compte.Username;
            Password = c.Compte.Password;
            Role = c.Compte.Role;
        }

        public int CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Qualification { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        

    }

}
