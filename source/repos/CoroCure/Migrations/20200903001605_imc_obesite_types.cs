using Microsoft.EntityFrameworkCore.Migrations;

namespace CoroCure.Migrations
{
    public partial class imc_obesite_types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Taille",
                table: "facteursRisqueAntecedants",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<double>(
                name: "IMC",
                table: "facteursRisqueAntecedants",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Taille",
                table: "facteursRisqueAntecedants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<int>(
                name: "IMC",
                table: "facteursRisqueAntecedants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
