using System;
using System.Collections.Generic;
using System.Text;
using CoroCure.Data.Entities;
using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public abstract class InterventionMedicaleDTO
    {
        public InterventionMedicaleDTO()
        {
        }

        public InterventionMedicaleDTO(InterventionMedicale entity)
        {
            this.Id = entity.Id;
            this.Nom = entity.Nom;
            this.Numero = entity.Numero;
            this.Date = entity.Date;
            this.estUrgente = entity.estUrgente;
            this.CIN = entity.CIN.GetValueOrDefault();

            if(entity.Cardiologue != null)
                this.Cardiologue = new CardiologueDTO(entity.Cardiologue);

            if(entity.Patient != null)
                this.Patient = new PatientDTO(entity.Patient);
        }

        public int Id { get; set; } 
        public string Nom { get; set; }
        public int Numero { get; set; }

        public DateTime Date { get; set; }
        public bool estUrgente { get; set; }
        public int CIN { get; set; }
        public CardiologueDTO Cardiologue { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public int BiologieId { get; set; }
        public BiologieDTO Biologie { get; set; }
    }
}
