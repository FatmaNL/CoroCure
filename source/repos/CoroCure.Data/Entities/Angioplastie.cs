using System;
using System.Collections.Generic;
using CoroCure.Data.DTO;

namespace CoroCure.Data.Entities
{
    public class Angioplastie : InterventionMedicale
    {
        public Angioplastie()
        {
        }

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
            this.Numero = dto.Numero;
            this.Nom = dto.Nom;
            this.Date = dto.Date;
            this.estUrgente = dto.estUrgente;
            this.CIN = dto.CIN;
            this.PatientId = dto.PatientId;

            if(dto.Procedures != null)
            {
                this.Procedures = new List<Procedure>();

                foreach (var procDto in dto.Procedures)
                {
                    var procedure = new Procedure
                    {
                        Angioplastie = this,
                        Resultat = procDto.Resultat,
                        Technique = procDto.Technique,
                        TIMIFinal = procDto.TIMIFinal
                    };
                    
                    if(procDto.Ballons != null)
                    {
                        procedure.Ballons = new List<Ballon>();

                        foreach (var ballonDto in procDto.Ballons)
                        {
                            var ballon = new Ballon
                            {
                                Type = ballonDto.Type,
                                CGReseauD = ballonDto.CGReseauD,
                                CGReseauG = ballonDto.CGReseauG,
                                Diametre = ballonDto.Diametre,
                                Longueur = ballonDto.Longueur,
                                Phase = ballonDto.Phase,
                                Pontage = ballonDto.Pontage,
                                TailleDesilet = ballonDto.TailleDesilet,
                                Procedure = procedure,
                            };

                            procedure.Ballons.Add(ballon);
                        }
                    }

                    if (procDto.Guides != null)
                    {
                        procedure.Guides = new List<Guide>();

                        foreach (var guideDto in procDto.Guides)
                        {
                            var guide = new Guide
                            {
                                Type = guideDto.Type,
                                CGReseauD = guideDto.CGReseauD,
                                CGReseauG = guideDto.CGReseauG,
                                Pontage = guideDto.Pontage,
                                TailleDesilet = guideDto.TailleDesilet,
                                Procedure = procedure,
                            };

                            procedure.Guides.Add(guide);
                        }
                    }

                    if (procDto.Stents != null)
                    {
                        procedure.Stents = new List<Stent>();

                        foreach (var stentDto in procDto.Stents)
                        {
                            var stent = new Stent
                            {
                                Type = stentDto.Type,
                                CGReseauD = stentDto.CGReseauD,
                                CGReseauG = stentDto.CGReseauG,
                                Diametre = stentDto.Diametre,
                                Longueur = stentDto.Longueur,
                                Pontage = stentDto.Pontage,
                                TailleDesilet = stentDto.TailleDesilet,
                                Procedure = procedure,
                            };

                            procedure.Stents.Add(stent);
                        }
                    }

                    this.Procedures.Add(procedure);
                }
            }
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
