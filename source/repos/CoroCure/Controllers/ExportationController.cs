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
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Path = System.IO.Path;

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

        [HttpGet]
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


        [HttpGet("pdf/{patientId}/{interventionId}")]
        public ActionResult Export([FromRoute] int patientId, [FromRoute] int interventionId)
        {
            var patient = _context.Patients.Where(p => p.Id == patientId)
                                           .Include(p => p.InterventionMedicales)
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
                    if (intervention is Coronarographie)
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

                        var biologie = intervention.Biologie;
                        if(biologie != null)
                        {
                            p = AjouterSousTitre(document, "Biologie");
                            p.Add($"Creat: {biologie.Creatinine}\n");
                            p.Add($"CLCreat: {biologie.CLCreatinine}\n");
                            p.Add($"IRC: {biologie.IRC}\n");
                            p.Add($"Hemoglobine: {biologie.Hemoglobine}\n");
                            p.Add($"INR: {biologie.INR}\n");
                        }

                        p.Add(AjouterSousTitre(document, "Contraste et Dosimetrie"));

                        p.Add(AjouterSousTitre(document, "Coro"));

                        p.Add(AjouterSousTitre(document, "Lesions"));

                        p.Add(AjouterSousTitre(document, "Matériels"));

                        p.Add(AjouterSousTitre(document, "Procedures"));
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

        [HttpGet("excel")]
        public ActionResult ExportExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excel = new ExcelPackage())
            {
                var patientWorksheet = excel.Workbook.Worksheets.Add("Patients");
                // var patientHeaderRow = new List<string[]>() { new string[] { "ID", "Nom", "Prenom", "DDN", "Sexe" } };
                //var patientHeaderRange = "A1:" + Char.ConvertFromUtf32(patientHeaderRow[0].Length + 64) + "1";
                // patientWorksheet.Cells[patientHeaderRange].LoadFromArrays(patientHeaderRow);
                var patients = _context.Patients.ToList();
                var patientsData = new List<object[]>();
                /*foreach (var p in patients)
                    patientsData.Add(new object[] { p.Id, p.Nom, p.Prenom, p.DateNaissance, p.Sexe });*/
                patientWorksheet.Cells[2, 1].LoadFromCollection<Patient>(patients, true);

                var cardWorksheet = excel.Workbook.Worksheets.Add("Cardiologues");
                // var cardHeaderRow = new List<string[]>() { new string[] { "CIN", "Nom", "Prenom", "Qualification" } };
                // var cardHeaderRange = "A1:" + Char.ConvertFromUtf32(cardHeaderRow[0].Length + 64) + "1";
                // cardWorksheet.Cells[cardHeaderRange].LoadFromArrays(cardHeaderRow);
                var cardiologues = _context.Cardiologues.ToList();
                cardWorksheet.Cells[2, 1].LoadFromCollection<Cardiologue>(cardiologues, true);

                var coroWorksheet = excel.Workbook.Worksheets.Add("Coro");
                // var coroHeaderRow = new List<string[]>() { new string[] { "ID", "Voie", "Statut", "Motif Principal", "AutreMotif" } };
                // var coroHeaderRange = "A1:" + Char.ConvertFromUtf32(coroHeaderRow[0].Length + 64) + "1";
                // cardWorksheet.Cells[coroHeaderRange].LoadFromArrays(coroHeaderRow);
                var coros = _context.Coronarographies.ToList();
                coroWorksheet.Cells[2, 1].LoadFromCollection<Coronarographie>(coros, true);

                var fileName = Path.GetTempFileName();
                var excelFile = new FileInfo(fileName);

                excel.SaveAs(excelFile);

                var file = new FileInfo(fileName);
                var dStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                return File(dStream, "application/xls");
            }

            
        }

        public System.Data.DataTable ExportToExcel()
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Sex", typeof(string));
            table.Columns.Add("Subject1", typeof(int));
            table.Columns.Add("Subject2", typeof(int));
            table.Columns.Add("Subject3", typeof(int));
            table.Columns.Add("Subject4", typeof(int));
            table.Columns.Add("Subject5", typeof(int));
            table.Columns.Add("Subject6", typeof(int));
            table.Rows.Add(1, "Amar", "M", 78, 59, 72, 95, 83, 77);
            table.Rows.Add(2, "Mohit", "M", 76, 65, 85, 87, 72, 90);
            table.Rows.Add(3, "Garima", "F", 77, 73, 83, 64, 86, 63);
            table.Rows.Add(4, "jyoti", "F", 55, 77, 85, 69, 70, 86);
            table.Rows.Add(5, "Avinash", "M", 87, 73, 69, 75, 67, 81);
            table.Rows.Add(6, "Devesh", "M", 92, 87, 78, 73, 75, 72);
            return table;
        }

        private Paragraph AjouterSousTitre(Document document, string text)
        {
            var motif = new Text(text);
            motif.SetBold();

            var p = new Paragraph(motif);
            p.Add(new Text("\n"));

            return p;
        }
    }
}
