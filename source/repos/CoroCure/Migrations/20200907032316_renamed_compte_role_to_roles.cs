using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class renamed_compte_role_to_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "compte");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "compte",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "compte");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "compte",
                type: "text",
                nullable: true);
        }
    }
}
