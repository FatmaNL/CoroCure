using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class LesionDTO
    {
        public int Id { get; set; }
        public string TypeLesion { get; set; }
        public double Degre { get; set; }
        public int FluxTIMI { get; set; }
        public int CoronarographieId { get; set; }
        public CoronarographieDTO Coronarographie { get; set; }
        public int DescriptionId { get; set; }
        public DescriptionDTO Description { get; set; }
    }
}