using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public abstract class InterventionMedicale
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Numero { get; set; }

        [Column("DateIntervention")]
        public DateTime Date { get; set; }
        public bool estUrgente { get; set; } // isUrgent()
        
        public int? CIN { get; set; }
        public Cardiologue Cardiologue { get; set; }
        
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        
        public int? BiologieId { get; set; }
        public virtual Biologie Biologie { get; set; }

    }
}
