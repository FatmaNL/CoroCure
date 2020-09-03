using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoroCure.Data.DTO;

namespace CoroCure.Data.Entities
{
    public class Biologie
    {
        public Biologie()
        {
        }

        public Biologie(BiologieDTO biologie)
        {
            this.Creatinine = biologie.Creatinine;
            this.CLCreatinine = biologie.CLCreatinine;
            this.IRC = biologie.IRC;
            this.Hemoglobine = biologie.Hemoglobine;
            this.INR = biologie.INR;
            this.PicTroponine = biologie.PicTroponine;
        }

        public int Id { get; set; }
        public double Creatinine { get; set; }
        public double CLCreatinine { get; set; }
        public string IRC { get; set; }
        public double Hemoglobine { get; set; }
        public int INR { get; set; }
        public int PicTroponine { get; set; }

        public InterventionMedicale InterventionMedicale { get; set; }
    }
}
