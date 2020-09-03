using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CoroCure.Data;
using CoroCure.Data.DTO;
using CoroCure.Data.Entities;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoroCure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportationController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ExportationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Get()
        {
            var patients = _context.Patients.Include(p => p.InterventionMedicales)
                                            .ThenInclude(i => i.Cardiologue);

            var exportations = new List<ExportationDTO>();
            foreach (var p in patients)
            {
                foreach (var i in p.InterventionMedicales)
                {
                    var exportationDto = new ExportationDTO();
                    exportationDto.NumeroDossier = p.Id;
                    exportationDto.Patient = $"{p.Nom} {p.Prenom}";
                    exportationDto.Intervention = i.GetType().Name;
                    exportationDto.NumeroIntervention = i.Id;
                    exportationDto.Cardiologue = $"{i.Cardiologue.Nom} {i.Cardiologue.Prenom}";

                    exportations.Add(exportationDto);
                }
            }

            return Ok(exportations);
        }


        [HttpGet("{patientId}/{interventionId}")]
        public ActionResult Export([FromRoute] int patientId, [FromRoute] int interventionId)
        {
            var patient = _context.Patients.Where(p => p.Id == patientId)
                                           .Include(p =>  p.InterventionMedicales)
                                                .ThenInclude(i => i.Cardiologue)
                                           .Include(p => p.InterventionMedicales)
                                                .ThenInclude(i => ((Coronarographie)i).FacteursRisqueAntecedants)
                                           .SingleOrDefault();

            var destination = $"rapport-intervention-{Guid.NewGuid()}.pdf";
            var file = new FileInfo(destination);
            var stream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            
            try
            {
                var pdfDoc = new PdfDocument(new PdfWriter(stream));
                var document = new Document(pdfDoc, PageSize.A4);

                foreach (var intervention in patient.InterventionMedicales)
                {
                    if(intervention is Coronarographie)
                    {
                        var coro = intervention as Coronarographie;
                        var title = new Paragraph($"Compte Rendu Coro : {intervention.Id}");
                        title.Add(new Text("\n"));
                        document.Add(title);
                        

                        var p = new Paragraph();
                        p.Add(new Text($"Patient Numero: {patient.Id}"));
                        p.Add(new Text("\n"));
                        p.Add(new Text($"Date Coro: {intervention.Date}"));
                        p.Add(new Text("\n"));
                        p.Add(new Text($"Operateur: {intervention.Cardiologue.Nom} {intervention.Cardiologue.Prenom}"));
                        p.Add(new Text("\n"));
                        document.Add(p);

                        var facteursTitle = new Text("Facteurs de risques et antécédents :");
                        facteursTitle.SetBold();
                        p = new Paragraph(facteursTitle);
                        p.Add(new Text("\n"));

                        if (intervention is Coronarographie)
                        {
                            var facteurs = (Coronarographie)intervention;
                            if (facteurs.FacteursRisqueAntecedants.AIT)
                            {
                                p.Add("AIT");
                                p.Add(new Text("\n"));
                            }


                            if (facteurs.FacteursRisqueAntecedants.Diabete)
                            {
                                p.Add("Diabete");
                                p.Add(new Text("\n"));
                            }

                            if (facteurs.FacteursRisqueAntecedants.Dysplidemie)
                            {
                                p.Add("Dysplidemie");
                                p.Add(new Text("\n"));
                            }

                            if (facteurs.FacteursRisqueAntecedants.ATCDATL)
                            {
                                p.Add("ATCDATL");
                                p.Add(new Text("\n"));
                            }

                            if (facteurs.FacteursRisqueAntecedants.AVCIsh)
                            {
                                p.Add("AVCIsh");
                                p.Add(new Text("\n"));
                            }
                        }
                        document.Add(p);

                        var motif = new Text("Motif de la coro :");
                        motif.SetBold();
                        p = new Paragraph(motif);
                        p.Add(new Text("\n"));

                        if (!string.IsNullOrWhiteSpace(coro.MotifPrinc))
                        {
                            p.Add(coro.MotifPrinc);
                            p.Add(new Text("\n"));
                        }

                        if (!string.IsNullOrWhiteSpace(coro.AutreMotif))
                        {
                            p.Add(coro.AutreMotif);
                            p.Add(new Text("\n"));
                        }
                        document.Add(p);
                    }    
                }
                
                document.Close();
            }
            catch (Exception)
            {

            }

            var dStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            return File(dStream, "application/octet-stream", $"rapport-intervention-{patientId}-{interventionId}.pdf");
        }
    }
}
