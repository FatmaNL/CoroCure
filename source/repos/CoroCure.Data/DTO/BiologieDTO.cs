using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class BiologieDTO
    {
        public int Id { get; set; }
        public double Creatinine { get; set; }
        public int CLCreatinine { get; set; }
        public string IRC { get; set; }
        public double Hemoglobine { get; set; }
        public int INR { get; set; }
        public int PicTroponine { get; set; }
        public InterventionMedicaleDTO InterventionMedicale { get; set; }
    }
}