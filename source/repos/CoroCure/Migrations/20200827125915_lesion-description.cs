using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CoroCure.Migrations
{
    public partial class lesiondescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "lesion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "description",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Segment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_description", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lesion_DescriptionId",
                table: "lesion",
                column: "DescriptionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lesion_description_DescriptionId",
                table: "lesion",
                column: "DescriptionId",
                principalTable: "description",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lesion_description_DescriptionId",
                table: "lesion");

            migrationBuilder.DropTable(
                name: "description");

            migrationBuilder.DropIndex(
                name: "IX_lesion_DescriptionId",
                table: "lesion");

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "lesion");
        }
    }
}
