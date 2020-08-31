using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class GuideDTO : MaterielDTO
    {
        public string Type { get; set; }

        public int ProcedureId { get; set; }
        public ProcedureDTO Procedure { get; set; }
    }
}