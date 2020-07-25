using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CoroCure.Migrations
{
    public partial class deletecascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "biologie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Creatinine = table.Column<double>(nullable: false),
                    CLCreatinine = table.Column<int>(nullable: false),
                    IRC = table.Column<string>(nullable: true),
                    Hemoglobine = table.Column<double>(nullable: false),
                    INR = table.Column<int>(nullable: false),
                    PicTroponine = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biologie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "compte",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    CIN = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compte", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "contrasteDosimetrie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypePDC = table.Column<string>(nullable: true),
                    QtePDC = table.Column<int>(nullable: false),
                    QtePDS = table.Column<int>(nullable: false),
                    NombreImages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrasteDosimetrie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "facteursRisqueAntecedants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Taille = table.Column<int>(nullable: false),
                    Poids = table.Column<int>(nullable: false),
                    IMC = table.Column<int>(nullable: false),
                    Obesite = table.Column<string>(nullable: true),
                    HTA = table.Column<bool>(nullable: false),
                    Diabete = table.Column<bool>(nullable: false),
                    TypeDiabete = table.Column<string>(nullable: true),
                    AncDiabete = table.Column<int>(nullable: false),
                    Tabac = table.Column<bool>(nullable: false),
                    Dysplidemie = table.Column<bool>(nullable: false),
                    AIT = table.Column<bool>(nullable: false),
                    AVCIsh = table.Column<bool>(nullable: false),
                    AVCHem = table.Column<bool>(nullable: false),
                    ATCDIDM = table.Column<bool>(nullable: false),
                    ATCDATL = table.Column<bool>(nullable: false),
                    ATCDPAC = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facteursRisqueAntecedants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    NSS = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Sexe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cardiologue",
                columns: table => new
                {
                    CIN = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Qualificaction = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cardiologue", x => x.CIN);
                    table.ForeignKey(
                        name: "FK_cardiologue_compte_Username",
                        column: x => x.Username,
                        principalTable: "compte",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "interventionMedicale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    DateIntervention = table.Column<DateTime>(nullable: false),
                    estUrgente = table.Column<bool>(nullable: false),
                    CIN = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    BiologieId = table.Column<int>(nullable: false),
                    TypeIntervention = table.Column<string>(nullable: false),
                    PADiastolique = table.Column<int>(nullable: true),
                    PASystolique = table.Column<int>(nullable: true),
                    FreqCardique = table.Column<int>(nullable: true),
                    AbordArterielPrincipal = table.Column<string>(nullable: true),
                    AnticoagulantIV = table.Column<string>(nullable: true),
                    AnticaogulantIVQte = table.Column<int>(nullable: true),
                    RisordanQte = table.Column<int>(nullable: true),
                    LoxenQte = table.Column<int>(nullable: true),
                    AntiGIIBIIIQte = table.Column<int>(nullable: true),
                    Voie = table.Column<string>(nullable: true),
                    Statut = table.Column<string>(nullable: true),
                    MotifPrinc = table.Column<string>(nullable: true),
                    AutreMotif = table.Column<string>(nullable: true),
                    FeVG = table.Column<double>(nullable: true),
                    FacteursRisqueAntecedantsId = table.Column<int>(nullable: true),
                    AngioplastieId = table.Column<int>(nullable: true),
                    ContrasteDosimetrieId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_interventionMedicale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_interventionMedicale_interventionMedicale_AngioplastieId",
                        column: x => x.AngioplastieId,
                        principalTable: "interventionMedicale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interventionMedicale_contrasteDosimetrie_ContrasteDosimetri~",
                        column: x => x.ContrasteDosimetrieId,
                        principalTable: "contrasteDosimetrie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interventionMedicale_facteursRisqueAntecedants_FacteursRisq~",
                        column: x => x.FacteursRisqueAntecedantsId,
                        principalTable: "facteursRisqueAntecedants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interventionMedicale_biologie_BiologieId",
                        column: x => x.BiologieId,
                        principalTable: "biologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interventionMedicale_cardiologue_CIN",
                        column: x => x.CIN,
                        principalTable: "cardiologue",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_interventionMedicale_patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lesion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeLesion = table.Column<string>(nullable: true),
                    Degre = table.Column<double>(nullable: false),
                    FluxTIMI = table.Column<int>(nullable: false),
                    CoronarographieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lesion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lesion_interventionMedicale_CoronarographieId",
                        column: x => x.CoronarographieId,
                        principalTable: "interventionMedicale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "procedure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Technique = table.Column<string>(nullable: true),
                    TIMIFinal = table.Column<int>(nullable: false),
                    Resultat = table.Column<string>(nullable: true),
                    AngioplastieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_procedure_interventionMedicale_AngioplastieId",
                        column: x => x.AngioplastieId,
                        principalTable: "interventionMedicale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "traitement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(nullable: true),
                    DateTraitement = table.Column<DateTime>(nullable: false),
                    Posologie = table.Column<int>(nullable: false),
                    AngioplastieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traitement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_traitement_interventionMedicale_AngioplastieId",
                        column: x => x.AngioplastieId,
                        principalTable: "interventionMedicale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "materiel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TailleDesilet = table.Column<int>(nullable: false),
                    CGReseauG = table.Column<string>(nullable: true),
                    CGReseauD = table.Column<string>(nullable: true),
                    Pontage = table.Column<string>(nullable: true),
                    AngioplastieId = table.Column<int>(nullable: true),
                    TypeMateriel = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Longueur = table.Column<int>(nullable: true),
                    Diametre = table.Column<int>(nullable: true),
                    Phase = table.Column<string>(nullable: true),
                    ProcedureId = table.Column<int>(nullable: true),
                    Guide_Type = table.Column<string>(nullable: true),
                    Guide_ProcedureId = table.Column<int>(nullable: true),
                    Stent_Type = table.Column<string>(nullable: true),
                    Stent_Longueur = table.Column<int>(nullable: true),
                    Stent_Diametre = table.Column<int>(nullable: true),
                    Marque = table.Column<string>(nullable: true),
                    PressionInf = table.Column<int>(nullable: true),
                    DureeInf = table.Column<int>(nullable: true),
                    Stent_ProcedureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materiel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_materiel_procedure_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_materiel_procedure_Guide_ProcedureId",
                        column: x => x.Guide_ProcedureId,
                        principalTable: "procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_materiel_interventionMedicale_AngioplastieId",
                        column: x => x.AngioplastieId,
                        principalTable: "interventionMedicale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_materiel_procedure_Stent_ProcedureId",
                        column: x => x.Stent_ProcedureId,
                        principalTable: "procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cardiologue_Username",
                table: "cardiologue",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_AngioplastieId",
                table: "interventionMedicale",
                column: "AngioplastieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_ContrasteDosimetrieId",
                table: "interventionMedicale",
                column: "ContrasteDosimetrieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_FacteursRisqueAntecedantsId",
                table: "interventionMedicale",
                column: "FacteursRisqueAntecedantsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_BiologieId",
                table: "interventionMedicale",
                column: "BiologieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_CIN",
                table: "interventionMedicale",
                column: "CIN");

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_PatientId",
                table: "interventionMedicale",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_lesion_CoronarographieId",
                table: "lesion",
                column: "CoronarographieId");

            migrationBuilder.CreateIndex(
                name: "IX_materiel_ProcedureId",
                table: "materiel",
                column: "ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_materiel_Guide_ProcedureId",
                table: "materiel",
                column: "Guide_ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_materiel_AngioplastieId",
                table: "materiel",
                column: "AngioplastieId");

            migrationBuilder.CreateIndex(
                name: "IX_materiel_Stent_ProcedureId",
                table: "materiel",
                column: "Stent_ProcedureId");

            migrationBuilder.CreateIndex(
                name: "IX_procedure_AngioplastieId",
                table: "procedure",
                column: "AngioplastieId");

            migrationBuilder.CreateIndex(
                name: "IX_traitement_AngioplastieId",
                table: "traitement",
                column: "AngioplastieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lesion");

            migrationBuilder.DropTable(
                name: "materiel");

            migrationBuilder.DropTable(
                name: "traitement");

            migrationBuilder.DropTable(
                name: "procedure");

            migrationBuilder.DropTable(
                name: "interventionMedicale");

            migrationBuilder.DropTable(
                name: "contrasteDosimetrie");

            migrationBuilder.DropTable(
                name: "facteursRisqueAntecedants");

            migrationBuilder.DropTable(
                name: "biologie");

            migrationBuilder.DropTable(
                name: "cardiologue");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "compte");
        }
    }
}
