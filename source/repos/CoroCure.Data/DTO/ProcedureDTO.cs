using System.Collections.Generic;
using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class ProcedureDTO
    {
        public int Id { get; set; }

        public string Technique { get; set; }

        public int TIMIFinal { get; set; }

        public string Resultat { get; set; }
        public int AngioplastieId { get; set; }
        public AngioplastieDTO Angioplastie { get; set; }
        public List<StentDTO> Stents { get; set; }
        public List<BallonDTO> Ballons { get; set; }
        public List<GuideDTO> Guides { get; set; }
    }
}