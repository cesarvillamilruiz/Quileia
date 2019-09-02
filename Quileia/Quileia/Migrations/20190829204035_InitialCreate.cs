using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quileia.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCiudad = table.Column<string>(nullable: true),
                    CantidaddeHabitantes = table.Column<int>(nullable: false),
                    SitioTuristico = table.Column<string>(nullable: true),
                    HotelMasReservado = table.Column<string>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                });

            migrationBuilder.CreateTable(
                name: "Turistas",
                columns: table => new
                {
                    TuristaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCompleto = table.Column<string>(nullable: true),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: true),
                    Identificacion = table.Column<string>(nullable: true),
                    FrecunciaDeViaje = table.Column<int>(nullable: false),
                    PresupuestoDeViaje = table.Column<double>(nullable: false),
                    CiudadId = table.Column<int>(nullable: true),
                    UsaTarjeta = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turistas", x => x.TuristaId);
                    table.ForeignKey(
                        name: "FK_Turistas_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TuristaCiudades",
                columns: table => new
                {
                    TuristaId = table.Column<int>(nullable: false),
                    CiudadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuristaCiudades", x => new { x.TuristaId, x.CiudadId });
                    table.ForeignKey(
                        name: "FK_TuristaCiudades_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TuristaCiudades_Turistas_TuristaId",
                        column: x => x.TuristaId,
                        principalTable: "Turistas",
                        principalColumn: "TuristaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TuristaCiudades_CiudadId",
                table: "TuristaCiudades",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Turistas_CiudadId",
                table: "Turistas",
                column: "CiudadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TuristaCiudades");

            migrationBuilder.DropTable(
                name: "Turistas");

            migrationBuilder.DropTable(
                name: "Ciudades");
        }
    }
}
