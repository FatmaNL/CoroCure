using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class Traitement
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        [Column("DateTraitement")]
        public DateTime Date { get; set; }
        public int Posologie { get; set; }
        public Angioplastie Agioplastie { get; set; }

    }
}
