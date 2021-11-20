﻿// <auto-generated />
using ARS_System.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ARS_System.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211120165117_Migracion_Inicial")]
    partial class Migracion_Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ARS_System.Entidades.Ciudades", b =>
                {
                    b.Property<int>("CiudadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CiudadId");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("ARS_System.Entidades.Especialidades", b =>
                {
                    b.Property<int>("EspecialidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreEspecialidad")
                        .HasColumnType("TEXT");

                    b.HasKey("EspecialidadId");

                    b.ToTable("Especialidades");

                    b.HasData(
                        new
                        {
                            EspecialidadId = 1,
                            NombreEspecialidad = "Pediatría"
                        });
                });

            modelBuilder.Entity("ARS_System.Entidades.Ocupaciones", b =>
                {
                    b.Property<int>("OcupacionesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("OcupacionesId");

                    b.ToTable("Ocupaciones");

                    b.HasData(
                        new
                        {
                            OcupacionesId = 1,
                            Nombre = "Plomero"
                        },
                        new
                        {
                            OcupacionesId = 2,
                            Nombre = "Electricista"
                        },
                        new
                        {
                            OcupacionesId = 3,
                            Nombre = "Abogado"
                        },
                        new
                        {
                            OcupacionesId = 4,
                            Nombre = "Ingeniero"
                        },
                        new
                        {
                            OcupacionesId = 5,
                            Nombre = "Chofer"
                        });
                });

            modelBuilder.Entity("ARS_System.Entidades.Provincias", b =>
                {
                    b.Property<int>("ProvinciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("ProvinciaId");

                    b.ToTable("Provincias");

                    b.HasData(
                        new
                        {
                            ProvinciaId = 1,
                            Nombres = "Duarte"
                        },
                        new
                        {
                            ProvinciaId = 2,
                            Nombres = "María Trinidad Sánchez"
                        },
                        new
                        {
                            ProvinciaId = 3,
                            Nombres = "Sánchez Ramirez"
                        },
                        new
                        {
                            ProvinciaId = 4,
                            Nombres = "Hermanas Mirabal"
                        },
                        new
                        {
                            ProvinciaId = 5,
                            Nombres = "La Vega"
                        },
                        new
                        {
                            ProvinciaId = 6,
                            Nombres = "Samaná"
                        });
                });

            modelBuilder.Entity("ARS_System.Entidades.Roles", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("RolId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ARS_System.Entidades.Ciudades", b =>
                {
                    b.HasOne("ARS_System.Entidades.Provincias", "Provincias")
                        .WithMany()
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincias");
                });
#pragma warning restore 612, 618
        }
    }
}
