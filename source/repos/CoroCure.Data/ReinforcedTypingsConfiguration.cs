using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using CoroCure.Data.DTO;
using Reinforced.Typings.Fluent;

namespace CoroCure.Data
{
    public static class ReinforcedTypingsConfiguration
    {
        public static void Configure(ConfigurationBuilder builder)
        {
            builder.Global(config =>
            {
                config.UseModules(true, true);
                config.TabSymbol(" ");
            });

            builder.ExportAsClass<AngioplastieDTO>().WithConstructor().WithAllProperties().ExportTo("angioplastie.dto.ts");
            builder.ExportAsClass<BallonDTO>().WithAllProperties().ExportTo("ballon.dto.ts");
            builder.ExportAsClass<BiologieDTO>().WithAllProperties().ExportTo("biologie.dto.ts");
            builder.ExportAsClass<CoronarographieDTO>().WithAllProperties().ExportTo("coronarographie.dto.ts");
            builder.ExportAsClass<CardiologueDTO>().WithAllProperties().ExportTo("cardiologue.dto.ts");
            builder.ExportAsClass<ContrasteDosimetrieDTO>().WithAllProperties().ExportTo("contraste-dosimetrie.dto.ts");
            builder.ExportAsClass<DescriptionDTO>().WithAllProperties().ExportTo("description.dto.ts");
            builder.ExportAsClass<FacteursRisqueAntecedantsDTO>().WithAllProperties().ExportTo("facteurs.dto.ts");
            builder.ExportAsClass<GuideDTO>().WithAllProperties().ExportTo("guide.dto.ts");
            builder.ExportAsClass<InterventionMedicaleDTO>().WithAllProperties().ExportTo("intervention.dto.ts");
            builder.ExportAsClass<LesionDTO>().WithAllProperties().ExportTo("lesion.dto.ts");
            builder.ExportAsClass<MaterielDTO>().WithAllProperties().ExportTo("materiel.dto.ts");
            builder.ExportAsClass<PatientDTO>().WithAllProperties().ExportTo("patient.dto.ts");
            builder.ExportAsClass<ProcedureDTO>().WithAllProperties().ExportTo("procedure.dto.ts");
            builder.ExportAsClass<StentDTO>().WithAllProperties().ExportTo("stent.dto.ts");
            builder.ExportAsClass<TraitementDTO>().WithAllProperties().ExportTo("traitement.dto.ts");
        }
    }
}
