using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoroCure.Data.DTO;

namespace CoroCure.Data.Entities
{
    public class FacteursRisqueAntecedants
    {
        public FacteursRisqueAntecedants()
        {
        }

        public FacteursRisqueAntecedants(FacteursRisqueAntecedantsDTO dto)
        {
            this.Id = dto.Id;
            this.Taille= dto.Taille;
            this.Poids = dto.Poids;
            this.IMC = dto.IMC;
            this.Obesite= dto.Obesite;
            this.HTA = dto.HTA;
            this.Diabete = dto.Diabete;
            this.TypeDiabete = dto.TypeDiabete;
            this.AncDiabete = dto.AncDiabete;
            this.Tabac = dto.Tabac;
            this.Dysplidemie = dto.Dysplidemie;
            this.AIT = dto.AIT;
            this.AVCIsh = dto.AVCIsh;
            this.AVCHem = dto.AVCHem;
            this.ATCDIDM = dto.ATCDIDM;
            this.ATCDATL = dto.ATCDATL;
            this.ATCDPAC = dto.ATCDPAC;
        }

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
