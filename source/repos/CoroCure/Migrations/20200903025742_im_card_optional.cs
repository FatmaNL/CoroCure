using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class im_card_optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_interventionMedicale_cardiologue_CIN",
                table: "interventionMedicale");

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

            migrationBuilder.AddForeignKey(
                name: "FK_interventionMedicale_cardiologue_CIN",
                table: "interventionMedicale",
                column: "CIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
