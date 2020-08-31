using System.Collections.Generic;

namespace CoroCure.Data.DTO
{
    public class CoronarographieDTO : InterventionMedicaleDTO
    {
        public string Voie { get; set; }
        public string Statut { get; set; }
        public string MotifPrinc { get; set; }
        public string AutreMotif { get; set; }
        public double FeVG { get; set; }
        
        public FacteursRisqueAntecedantsDTO FacteursRisqueAntecedants { get; set; }
        public AngioplastieDTO Angioplastie { get; set; }
        public ContrasteDosimetrieDTO ContrasteDosimetrie { get; set; }
        public List<LesionDTO> Lesions { get; set; }
    }
}
