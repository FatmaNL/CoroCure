using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Biologie
    {
        public int Id { get; set; }
        public double Creatinine { get; set; }
        public int CLCreatinine { get; set; }
        public string IRC { get; set; }
        public double Hemoglobine { get; set; }
        public int INR { get; set; }
        public int PicTroponine { get; set; }
        public InterventionMedicale InterventionMedicale { get; set; }
    }
}
