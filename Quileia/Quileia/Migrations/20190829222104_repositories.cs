using Microsoft.EntityFrameworkCore.Migrations;

namespace Quileia.Migrations
{
    public partial class repositories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turistas_Ciudades_CiudadId",
                table: "Turistas");

            migrationBuilder.RenameColumn(
                name: "CiudadId",
                table: "Turistas",
                newName: "ciudadId");

            migrationBuilder.RenameColumn(
                name: "TuristaId",
                table: "Turistas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Turistas_CiudadId",
                table: "Turistas",
                newName: "IX_Turistas_ciudadId");

            migrationBuilder.RenameColumn(
                name: "CiudadId",
                table: "Ciudades",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Turistas_Ciudades_ciudadId",
                table: "Turistas",
                column: "ciudadId",
                principalTable: "Ciudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turistas_Ciudades_ciudadId",
                table: "Turistas");

            migrationBuilder.RenameColumn(
                name: "ciudadId",
                table: "Turistas",
                newName: "CiudadId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Turistas",
                newName: "TuristaId");

            migrationBuilder.RenameIndex(
                name: "IX_Turistas_ciudadId",
                table: "Turistas",
                newName: "IX_Turistas_CiudadId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ciudades",
                newName: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turistas_Ciudades_CiudadId",
                table: "Turistas",
                column: "CiudadId",
                principalTable: "Ciudades",
                principalColumn: "CiudadId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
