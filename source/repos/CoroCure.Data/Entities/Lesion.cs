using CoroCure.Data.DTO;

namespace CoroCure.Data.Entities
{
    public class Lesion
    {
        public Lesion()
        {
        }

        public Lesion(LesionDTO dto)
        {
            this.TypeLesion = dto.TypeLesion;
            this.Degre = dto.Degre;
            this.FluxTIMI = dto.FluxTIMI;
            
            this.CoronarographieId = dto.CoronarographieId;
            this.DescriptionId = dto.DescriptionId;
        }

        public int Id { get; set; }
        public string TypeLesion { get; set; }
        public double Degre { get; set; }
        public int FluxTIMI { get; set; }
        public int CoronarographieId { get; set; }
        public Coronarographie Coronarographie { get; set; }
        public int DescriptionId { get; set; }
        public Description Description { get; set; }

    }
}
