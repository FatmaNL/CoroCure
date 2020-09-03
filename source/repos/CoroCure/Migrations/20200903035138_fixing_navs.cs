using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class fixing_navs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_cardiologue_CardiologueCIN",
                table: "interventionMedicale");

            migrationBuilder.DropIndex(
                name: "IX_interventionMedicale_CardiologueCIN",
                table: "interventionMedicale");

            migrationBuilder.DropColumn(
                name: "CardiologueCIN",
                table: "interventionMedicale");

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_CIN",
                table: "interventionMedicale",
                column: "CIN");

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_cardiologue_CIN",
                table: "interventionMedicale",
                column: "CIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_cardiologue_CIN",
                table: "interventionMedicale");

            migrationBuilder.DropIndex(
                name: "IX_interventionMedicale_CIN",
                table: "interventionMedicale");

            migrationBuilder.AddColumn<int>(
                name: "CardiologueCIN",
                table: "interventionMedicale",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_interventionMedicale_CardiologueCIN",
                table: "interventionMedicale",
                column: "CardiologueCIN");

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_cardiologue_CardiologueCIN",
                table: "interventionMedicale",
                column: "CardiologueCIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
