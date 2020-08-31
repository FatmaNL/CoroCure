using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class StentDTO : MaterielDTO
    {
        public string Type { get; set; }

        public int Longueur { get; set; }

        public int Diametre { get; set; }

        public string Marque { get; set; }

        public int PressionInf { get; set; }

        public int DureeInf { get; set; }

        public int ProcedureId { get; set; }
        public ProcedureDTO Procedure { get; set; }
    }
}