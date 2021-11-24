using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_System.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aseguradoras",
                columns: table => new
                {
                    AseguradoraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    RNC = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    CiudadId = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aseguradoras", x => x.AseguradoraId);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    DiagnosticoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.DiagnosticoId);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspecialidadId);
                });

            migrationBuilder.CreateTable(
                name: "Ocupaciones",
                columns: table => new
                {
                    OcupacionesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupaciones", x => x.OcupacionesId);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.PermisoId);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ProvinciaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ProvinciaId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioId);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    SexoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    ProvinciaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                    table.ForeignKey(
                        name: "FK_Ciudades_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "ProvinciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Contrasena = table.Column<string>(type: "TEXT", nullable: true),
                    RolId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Afiliados",
                columns: table => new
                {
                    AfiliadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    SexoId = table.Column<int>(type: "INTEGER", nullable: false),
                    NSS = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    CiudadId = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorReclamado = table.Column<float>(type: "REAL", nullable: false),
                    AseguradoraId = table.Column<int>(type: "INTEGER", nullable: false),
                    OcupacionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliados", x => x.AfiliadoId);
                    table.ForeignKey(
                        name: "FK_Afiliados_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliados_Ocupaciones_OcupacionId",
                        column: x => x.OcupacionId,
                        principalTable: "Ocupaciones",
                        principalColumn: "OcupacionesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliados_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "SexoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctores",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    CiudadId = table.Column<int>(type: "INTEGER", nullable: false),
                    Exequatur = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctores", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctores_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestadores",
                columns: table => new
                {
                    PrestadorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    RNC = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    CiudadId = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestadores", x => x.PrestadorId);
                    table.ForeignKey(
                        name: "FK_Prestadores_Ciudades_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudades",
                        principalColumn: "CiudadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermisoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Observacion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosDetalle_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "PermisoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosDetalle_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctoresDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false),
                    EspecialidadId = table.Column<int>(type: "INTEGER", nullable: false),
                    Observacion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctoresDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctoresDetalle_Doctores_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctores",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctoresDetalle_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "EspecialidadId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aseguradoras",
                columns: new[] { "AseguradoraId", "CiudadId", "Direccion", "Nombres", "RNC", "Telefono" },
                values: new object[] { 1, 1, "Calle San Francisco", "Humano", "101506254", "809-555-9632" });

            migrationBuilder.InsertData(
                table: "Diagnosticos",
                columns: new[] { "DiagnosticoId", "Nombres" },
                values: new object[] { 1, "Anemia" });

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "EspecialidadId", "Nombres" },
                values: new object[] { 1, "Pediatría" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionesId", "Nombre" },
                values: new object[] { 1, "Plomero" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionesId", "Nombre" },
                values: new object[] { 2, "Electricista" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionesId", "Nombre" },
                values: new object[] { 3, "Abogado" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionesId", "Nombre" },
                values: new object[] { 4, "Ingeniero" });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "OcupacionesId", "Nombre" },
                values: new object[] { 5, "Chofer" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 6, "Samaná" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 5, "La Vega" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 4, "Hermanas Mirabal" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 2, "María Trinidad Sánchez" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 1, "Duarte" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 3, "Sánchez Ramirez" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "Nombre" },
                values: new object[] { 1, "Administrador" });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "ServicioId", "Descripcion" },
                values: new object[] { 1, "Consulta" });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "ServicioId", "Descripcion" },
                values: new object[] { 2, "Emergencia" });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "SexoId", "Nombres" },
                values: new object[] { 1, "Femenino" });

            migrationBuilder.InsertData(
                table: "Sexos",
                columns: new[] { "SexoId", "Nombres" },
                values: new object[] { 2, "Masculino" });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "CiudadId", "Nombres", "ProvinciaId" },
                values: new object[] { 1, "San Francisco de Macoris", 1 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Contrasena", "Nombres", "RolId", "Username" },
                values: new object[] { 1, "d7678f190ca1811f2d340c7aa1bf1822e6acaac89ffd8ea5c2f731efd3e10e4a", "Kelvin Peña", 1, "KelvinP" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Contrasena", "Nombres", "RolId", "Username" },
                values: new object[] { 2, "c25a957fe06e03fbbc5b8f9635c1addd4e1c62a2a7d6d1286faae96e603e9a15", "Nachely Sanchez", 1, "NachelyS" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Contrasena", "Nombres", "RolId", "Username" },
                values: new object[] { 3, "613ba1ddd8c16ecb4f619506e8d88e25c94b98d33b4c9a23d67910bcb0161a6d", "Vismar Lora", 1, "VismarL" });

            migrationBuilder.InsertData(
                table: "Doctores",
                columns: new[] { "DoctorId", "Celular", "CiudadId", "Direccion", "Exequatur", "Nombres", "Telefono" },
                values: new object[] { 1, "829-213-9632", 1, "Calle 27 de Febrero", "123-45", "Frank Felix Ventura", "809-555-6589" });

            migrationBuilder.InsertData(
                table: "Prestadores",
                columns: new[] { "PrestadorId", "CiudadId", "Direccion", "Nombres", "RNC", "Telefono" },
                values: new object[] { 1, 1, "C/ Salcedo Esq. San Francisco", "Centro Médico Nacional, San Francisco", "A1053736146", "809-588-3414" });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_CiudadId",
                table: "Afiliados",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_OcupacionId",
                table: "Afiliados",
                column: "OcupacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_SexoId",
                table: "Afiliados",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_ProvinciaId",
                table: "Ciudades",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctores_CiudadId",
                table: "Doctores",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctoresDetalle_DoctorId",
                table: "DoctoresDetalle",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctoresDetalle_EspecialidadId",
                table: "DoctoresDetalle",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestadores_CiudadId",
                table: "Prestadores",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosDetalle_PermisoId",
                table: "UsuariosDetalle",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosDetalle_UsuarioId",
                table: "UsuariosDetalle",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afiliados");

            migrationBuilder.DropTable(
                name: "Aseguradoras");

            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "DoctoresDetalle");

            migrationBuilder.DropTable(
                name: "Prestadores");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "UsuariosDetalle");

            migrationBuilder.DropTable(
                name: "Ocupaciones");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "Doctores");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
