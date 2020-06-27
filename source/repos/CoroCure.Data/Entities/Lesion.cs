using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Lesion
    {
        public int Id { get; set; }
        public string TypeLesion { get; set; }
        public double Degre { get; set; }
        public int FluxTIMI { get; set; }
        public Coronarographie Coronarographie { get; set; }

    }
}
