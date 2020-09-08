using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class card_compte_cascade_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compte_cardiologue_CIN",
                table: "compte");

            migrationBuilder.AddForeignKey(
                name: "FK_compte_cardiologue_CIN",
                table: "compte",
                column: "CIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compte_cardiologue_CIN",
                table: "compte");

            migrationBuilder.AddForeignKey(
                name: "FK_compte_cardiologue_CIN",
                table: "compte",
                column: "CIN",
                principalTable: "cardiologue",
                principalColumn: "CIN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
