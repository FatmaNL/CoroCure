using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class MaterielDTO
    {
        public int Id { get; set; }

        public int TailleDesilet { get; set; }

        public string CGReseauG { get; set; }

        public string CGReseauD { get; set; }

        public string Pontage { get; set; }
        public AngioplastieDTO Angioplastie { get; set; }
    }
}