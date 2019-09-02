using Microsoft.EntityFrameworkCore.Migrations;

namespace Quileia.Migrations
{
    public partial class Initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turistas_Ciudades_ciudadId",
                table: "Turistas");

            migrationBuilder.DropIndex(
                name: "IX_Turistas_ciudadId",
                table: "Turistas");

            migrationBuilder.DropColumn(
                name: "ciudadId",
                table: "Turistas");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Ciudades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ciudadId",
                table: "Turistas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Ciudades",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Turistas_ciudadId",
                table: "Turistas",
                column: "ciudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turistas_Ciudades_ciudadId",
                table: "Turistas",
                column: "ciudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
