using CoroCure.Data.DTO;

namespace CoroCure.Data.Entities
{
    public class ContrasteDosimetrie
    {
        private ContrasteDosimetrieDTO contrasteDosimetrie;

        public ContrasteDosimetrie()
        {
        }
        public ContrasteDosimetrie(ContrasteDosimetrieDTO contrasteDosimetrie)
        {
            this.contrasteDosimetrie = contrasteDosimetrie;
        }

        public int Id { get; set; }
        public string TypePDC { get; set; }
        public int QtePDC { get; set; }
        public int QtePDS { get; set; }
        public int NombreImages { get; set; }
        public Coronarographie Coronarographie { get; set; }
    }
}
