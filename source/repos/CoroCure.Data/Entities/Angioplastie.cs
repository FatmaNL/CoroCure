using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CoroCure.Data.DTO;

namespace CoroCure.Data.Entities
{
    public class Angioplastie : InterventionMedicale
    {
        public Angioplastie(AngioplastieDTO dto)
        {
            this.PADiastolique = dto.PADiastolique;
            this.PASystolique = dto.PASystolique;
            this.FreqCardique = dto.FreqCardique;
            this.AbordArterielPrincipal = dto.AbordArterielPrincipal;
            this.AnticoagulantIV = dto.AnticoagulantIV;
            this.AnticaogulantIVQte = dto.AnticaogulantIVQte;
            this.RisordanQte = dto.RisordanQte;
            this.LoxenQte = dto.LoxenQte;
            this.RisordanQte = dto.RisordanQte;
            this.AntiGIIBIIIQte = dto.AntiGIIBIIIQte;
        }

        public int PADiastolique { get; set; }
        public int PASystolique { get; set; }
        public int FreqCardique { get; set; }
        public string AbordArterielPrincipal { get; set; }
        public string AnticoagulantIV { get; set; }
        public int AnticaogulantIVQte { get; set; }
        public int RisordanQte { get; set; }
        public int LoxenQte { get; set; }
        public int AntiGIIBIIIQte { get; set; }
        public Coronarographie Coronarographie { get; set; }
        public List<Traitement> Traitements { get; set; }
        public List<Materiel> Materiels { get; set; }
        public List<Procedure> Procedures { get; set; }
        

    }
}
