using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Procedure
    {
        public int Id { get; set; }

        public string Technique { get; set; }

        public int TIMIFinal { get; set; }

        public string Resultat { get; set; }
        public int AngioplastieId { get; set; }
        public Angioplastie Angioplastie { get; set; }
        public List<Stent> Stents { get; set; }
        public List<Ballon> Ballons { get; set; }
        public List<Guide> Guides { get; set; }

    }
}
