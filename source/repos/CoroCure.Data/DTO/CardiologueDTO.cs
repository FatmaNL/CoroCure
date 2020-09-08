using CoroCure.Data.Entities;

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
            Roles = c.Compte.Roles;
        }

        public int CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Qualification { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }

}
