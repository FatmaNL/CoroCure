using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class nav_properties_fix_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_patient_PatientId",
                table: "interventionMedicale");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "interventionMedicale",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "interventionMedicale",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
