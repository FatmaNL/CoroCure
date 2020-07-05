using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Ballon : Materiel
    {

        public string Type { get; set; }

        public int Longueur { get; set; }

        public int Diametre { get; set; }

        public string Phase { get; set; }
        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }

    }
}
