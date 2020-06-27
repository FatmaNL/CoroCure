using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoroCure.Data.Entities
{
    public class FacteursRisqueAntecedants
    {
        public int Id { get; set; }
        public int Taille { get; set; }
        public int Poids { get; set; }
        public int IMC { get; set; }
        public string Obesite { get; set; }
        public bool HTA { get; set; }
        public bool Diabete { get; set; }
        public string TypeDiabete { get; set; }
        public int AncDiabete { get; set; }
        public bool Tabac { get; set; }
        public bool Dysplidemie { get; set; }
        public bool AIT { get; set; }
        public bool AVCIsh { get; set; }
        public bool AVCHem { get; set; }
        public bool ATCDIDM { get; set; }
        public bool ATCDATL { get; set; }
        public bool ATCDPAC { get; set; }
        public Coronarographie Coronarographie { get; set; }

    }
}
