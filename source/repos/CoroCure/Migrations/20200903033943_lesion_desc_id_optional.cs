using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class lesion_desc_id_optional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lesion_description_DescriptionId",
                table: "lesion");

            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "lesion",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_lesion_description_DescriptionId",
                table: "lesion",
                column: "DescriptionId",
                principalTable: "description",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lesion_description_DescriptionId",
                table: "lesion");

            migrationBuilder.AlterColumn<int>(
                name: "DescriptionId",
                table: "lesion",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_lesion_description_DescriptionId",
                table: "lesion",
                column: "DescriptionId",
                principalTable: "description",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
