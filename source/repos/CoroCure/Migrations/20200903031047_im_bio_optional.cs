using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class im_bio_optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_biologie_BiologieId",
                table: "interventionMedicale");

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_biologie_BiologieId",
                table: "interventionMedicale",
                column: "BiologieId",
                principalTable: "biologie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_biologie_BiologieId",
                table: "interventionMedicale");

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_biologie_BiologieId",
                table: "interventionMedicale",
                column: "BiologieId",
                principalTable: "biologie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
