using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class nav_properties_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compte_cardiologue_CIN",
                table: "compte");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_biologie_BiologieId",
                table: "interventionMedicale");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_cardiologue_CIN",
                table: "interventionMedicale");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale");

            migrationBuilder.DropIndex(
                name: "IX_interventionMedicale_CIN",
                table: "interventionMedicale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_biologie",
                table: "biologie");

            migrationBuilder.RenameTable(
                name: "biologie",
                newName: "Biologies");

            migrationBuilder.AddColumn<int>(
                name: "CardiologueCIN",
                table: "interventionMedicale",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biologies",
                table: "Biologies",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_CardiologueCIN",
                table: "interventionMedicale",
                column: "CardiologueCIN");

            migrationBuilder.AddForeignKey(
                name: "FK_compte_cardiologue_CIN",
                table: "compte",
                column: "CIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_Biologies_BiologieId",
                table: "interventionMedicale",
                column: "BiologieId",
                principalTable: "Biologies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_cardiologue_CardiologueCIN",
                table: "interventionMedicale",
                column: "CardiologueCIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compte_cardiologue_CIN",
                table: "compte");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_Biologies_BiologieId",
                table: "interventionMedicale");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_cardiologue_CardiologueCIN",
                table: "interventionMedicale");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale");

            migrationBuilder.DropIndex(
                name: "IX_interventionMedicale_CardiologueCIN",
                table: "interventionMedicale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Biologies",
                table: "Biologies");

            migrationBuilder.DropColumn(
                name: "CardiologueCIN",
                table: "interventionMedicale");

            migrationBuilder.RenameTable(
                name: "Biologies",
                newName: "biologie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_biologie",
                table: "biologie",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_CIN",
                table: "interventionMedicale",
                column: "CIN");

            migrationBuilder.AddForeignKey(
                name: "FK_compte_cardiologue_CIN",
                table: "compte",
                column: "CIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_biologie_BiologieId",
                table: "interventionMedicale",
                column: "BiologieId",
                principalTable: "biologie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_cardiologue_CIN",
                table: "interventionMedicale",
                column: "CIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
