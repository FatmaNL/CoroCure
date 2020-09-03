using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class fixing_navs_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_interventionMedicale_AngioplastieId",
                table: "interventionMedicale");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_contrasteDosimetrie_ContrasteDosimetri~",
                table: "interventionMedicale");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_facteursRisqueAntecedants_FacteursRisq~",
                table: "interventionMedicale");

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_interventionMedicale_AngioplastieId",
                table: "interventionMedicale",
                column: "AngioplastieId",
                principalTable: "interventionMedicale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_contrasteDosimetrie_ContrasteDosimetri~",
                table: "interventionMedicale",
                column: "ContrasteDosimetrieId",
                principalTable: "contrasteDosimetrie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_facteursRisqueAntecedants_FacteursRisq~",
                table: "interventionMedicale",
                column: "FacteursRisqueAntecedantsId",
                principalTable: "facteursRisqueAntecedants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_interventionMedicale_AngioplastieId",
                table: "interventionMedicale");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_contrasteDosimetrie_ContrasteDosimetri~",
                table: "interventionMedicale");

            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_facteursRisqueAntecedants_FacteursRisq~",
                table: "interventionMedicale");

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_interventionMedicale_AngioplastieId",
                table: "interventionMedicale",
                column: "AngioplastieId",
                principalTable: "interventionMedicale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_contrasteDosimetrie_ContrasteDosimetri~",
                table: "interventionMedicale",
                column: "ContrasteDosimetrieId",
                principalTable: "contrasteDosimetrie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_facteursRisqueAntecedants_FacteursRisq~",
                table: "interventionMedicale",
                column: "FacteursRisqueAntecedantsId",
                principalTable: "facteursRisqueAntecedants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
