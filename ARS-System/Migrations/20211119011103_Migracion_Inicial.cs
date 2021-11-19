using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_System.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    CiudadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCiudad = table.Column<string>(type: "TEXT", nullable: true),
                    Provincia = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.CiudadId);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    EspecialidadId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreEspecialidad = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.EspecialidadId);
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

            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "EspecialidadId", "NombreEspecialidad" },
                values: new object[] { 1, "Pediatría" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 1, "Duarte" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 2, "María Trinidad Sánchez" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 3, "Sánchez Ramirez" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 4, "Hermanas Mirabal" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 5, "La Vega" });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "ProvinciaId", "Nombres" },
                values: new object[] { 6, "Samaná" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
