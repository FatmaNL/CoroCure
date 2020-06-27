using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Materiel
    {
        public int Id { get; set; }

        public int TailleDesilet { get; set; }

        public string CGReseauG { get; set; }

        public string CGReseauD { get; set; }

        public string Pontage{ get; set; }
        public Angioplastie Angioplastie { get; set; }
        
    }
}
