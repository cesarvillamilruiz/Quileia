﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quileia.Data;

namespace Quileia.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190829222104_repositories")]
    partial class repositories
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quileia.Data.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidaddeHabitantes");

                    b.Property<string>("HotelMasReservado");

                    b.Property<int>("MyProperty");

                    b.Property<string>("NombreCiudad");

                    b.Property<string>("SitioTuristico");

                    b.HasKey("Id");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Quileia.Data.Entities.Turista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FechaDeNacimiento");

                    b.Property<int>("FrecunciaDeViaje");

                    b.Property<string>("Identificacion");

                    b.Property<string>("NombreCompleto");

                    b.Property<double>("PresupuestoDeViaje");

                    b.Property<bool>("UsaTarjeta");

                    b.Property<int?>("ciudadId");

                    b.HasKey("Id");

                    b.HasIndex("ciudadId");

                    b.ToTable("Turistas");
                });

            modelBuilder.Entity("Quileia.Data.Entities.TuristaCiudad", b =>
                {
                    b.Property<int>("TuristaId");

                    b.Property<int>("CiudadId");

                    b.HasKey("TuristaId", "CiudadId");

                    b.HasIndex("CiudadId");

                    b.ToTable("TuristaCiudades");
                });

            modelBuilder.Entity("Quileia.Data.Entities.Turista", b =>
                {
                    b.HasOne("Quileia.Data.Entities.Ciudad", "ciudad")
                        .WithMany()
                        .HasForeignKey("ciudadId");
                });

            modelBuilder.Entity("Quileia.Data.Entities.TuristaCiudad", b =>
                {
                    b.HasOne("Quileia.Data.Entities.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Quileia.Data.Entities.Turista", "Turista")
                        .WithMany()
                        .HasForeignKey("TuristaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
