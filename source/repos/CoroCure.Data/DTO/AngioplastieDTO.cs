using System.Collections.Generic;
using CoroCure.Data.Entities;
using Reinforced.Typings.Attributes;

namespace CoroCure.Data.DTO
{
    public class AngioplastieDTO : InterventionMedicaleDTO
    {
        private InterventionMedicale i;

        public AngioplastieDTO(InterventionMedicale i)
        {
            this.i = i;
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
        public CoronarographieDTO Coronarographie { get; set; }
        public List<TraitementDTO> Traitements { get; set; }
        public List<MaterielDTO> Materiels { get; set; }
        public List<ProcedureDTO> Procedures { get; set; }
    }
}