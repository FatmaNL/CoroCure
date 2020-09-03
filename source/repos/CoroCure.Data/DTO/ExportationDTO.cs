using System.Collections.Generic;

namespace CoroCure.Data.DTO
{
    public class ExportationDTO
    {   
        public int NumeroDossier { get; set; }
        public string Patient { get; set; }
        public string Intervention { get; set; }
        public int NumeroIntervention { get; set; }
        public string Cardiologue { get; set; }

    }
}
