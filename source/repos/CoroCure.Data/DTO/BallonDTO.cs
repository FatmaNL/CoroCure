using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class BallonDTO : MaterielDTO
    {
        public string Type { get; set; }

        public int Longueur { get; set; }

        public int Diametre { get; set; }

        public string Phase { get; set; }

        public int ProcedureId { get; set; }
        public ProcedureDTO Procedure { get; set; }
    }
}