﻿using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class FacteursRisqueAntecedantsDTO
    {
        public int Id { get; set; }
        public double Taille { get; set; }
        public int Poids { get; set; }
        public double IMC { get; set; }
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
        public CoronarographieDTO Coronarographie { get; set; }
    }
}