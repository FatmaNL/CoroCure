using System.Collections.Generic;
using System.Linq;
using CoroCure.Data.DTO;

namespace CoroCure.Data.Entities
{
    public class Coronarographie : InterventionMedicale
    {
        public Coronarographie(CoronarographieDTO dto)
        {
            this.Id = dto.Id;
            this.Nom = dto.Nom;
            this.Numero = dto.Numero;

            this.Voie = dto.Voie;
            this.Statut = dto.Statut;
            this.MotifPrinc = dto.MotifPrinc;
            this.AutreMotif = dto.AutreMotif;
            this.FeVG = dto.FeVG;

            if (dto.FacteursRisqueAntecedants != null)
            {
                this.FacteursRisqueAntecedantsId = dto.FacteursRisqueAntecedants.Id;
                this.FacteursRisqueAntecedants = new FacteursRisqueAntecedants(dto.FacteursRisqueAntecedants);
            }

            if (dto.Angioplastie != null)
            {
                this.AngioplastieId = dto.Angioplastie.Id;
                this.Angioplastie = new Angioplastie(dto.Angioplastie);
            }

            if (dto.ContrasteDosimetrie != null)
            {
                this.ContrasteDosimetrieId = dto.ContrasteDosimetrie.Id;
                this.ContrasteDosimetrie = new ContrasteDosimetrie(dto.ContrasteDosimetrie);
            }

            if (dto.Lesions != null && dto.Lesions.Any())
            {
                this.Lesions = new List<Lesion>();
                foreach (var lesionDto in dto.Lesions)
                {
                    var lesion = new Lesion(lesionDto);
                    this.Lesions.Add(lesion);
                }
            }
        }

        public string Voie { get; set; }
        public string Statut { get; set; }
        public string MotifPrinc { get; set; }
        public string AutreMotif { get; set; }
        public double FeVG { get; set; }

        public int FacteursRisqueAntecedantsId { get; set; }
        public FacteursRisqueAntecedants FacteursRisqueAntecedants { get; set; }

        public int AngioplastieId { get; set; }
        public Angioplastie Angioplastie { get; set; }

        public int ContrasteDosimetrieId { get; set; }
        public ContrasteDosimetrie ContrasteDosimetrie { get; set; }

        public List<Lesion> Lesions { get; set; }
    }
}
