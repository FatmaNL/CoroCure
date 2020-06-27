using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Stent : Materiel
    {

        public string Type { get; set; }

        public int Longueur { get; set; }

        public int Diametre { get; set; }

        public string Marque { get; set; }

        public int PressionInf { get; set; }

        public int DureeInf { get; set; }
        public Procedure Procedure { get; set; }

    }
}
