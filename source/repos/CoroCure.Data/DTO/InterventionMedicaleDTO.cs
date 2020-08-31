using System;
using System.Collections.Generic;
using System.Text;
using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public abstract class InterventionMedicaleDTO
    {
        public int Id { get; }
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
