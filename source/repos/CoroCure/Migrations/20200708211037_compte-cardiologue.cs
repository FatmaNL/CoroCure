using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class comptecardiologue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cardiologue_compte_Username",
                table: "cardiologue");

            migrationBuilder.DropIndex(
                name: "IX_cardiologue_Username",
                table: "cardiologue");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "cardiologue");

            migrationBuilder.CreateIndex(
                name: "IX_compte_CIN",
                table: "compte",
                column: "CIN",
                unique: true);

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

            migrationBuilder.DropIndex(
                name: "IX_compte_CIN",
                table: "compte");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "cardiologue",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_cardiologue_Username",
                table: "cardiologue",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cardiologue_compte_Username",
                table: "cardiologue",
                column: "Username",
                principalTable: "compte",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
