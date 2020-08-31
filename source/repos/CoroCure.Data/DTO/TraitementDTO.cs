using System;
using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class TraitementDTO
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public DateTime Date { get; set; }

        public int Posologie { get; set; }

        public int AngioplastieId { get; set; }
        public AngioplastieDTO Angioplastie { get; set; }
    }
}