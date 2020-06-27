using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Coronarographie : InterventionMedicale
    {
        public string Voie { get; set; }
        public string Statut { get; set; }
        public string MotifPrinc { get; set; }
        public string AutreMotif { get; set; }
        public double FeVG { get; set; }
        public int FacteursRisqueAntecedantsId { get; set; }
        public FacteursRisqueAntecedants FacteursRisqueAntecedants { get; set; }

        public int AngioplastieId { get; set; }
        public Angioplastie Angioplastie { get; set; }
        public int ContrasteDosimetrieId { get; set; }
        public ContrasteDosimetrie ContrasteDosimetrie { get; set; }
        public List<Lesion> Lesions { get; set; }

    }
}
