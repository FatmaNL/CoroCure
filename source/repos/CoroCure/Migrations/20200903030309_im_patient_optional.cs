using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class im_patient_optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale");

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale");

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
