using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class ContrasteDosimetrieDTO
    {
        public int Id { get; set; }
        public string TypePDC { get; set; }
        public int QtePDC { get; set; }
        public int QtePDS { get; set; }
        public int NombreImages { get; set; }
        public CoronarographieDTO Coronarographie { get; set; }
    }
}