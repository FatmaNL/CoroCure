using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class ContrasteDosimetrie
    {
        public int Id { get; set; }
        public string TypePDC { get; set; }
        public int QtePDC { get; set; }
        public int QtePDS { get; set; }
        public int NombreImages { get; set; }
        public Coronarographie Coronarographie { get; set; }
    }
}
