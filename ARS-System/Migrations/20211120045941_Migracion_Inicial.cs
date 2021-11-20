using Microsoft.EntityFrameworkCore.Migrations;

namespace ARS_System.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_ProvinciaId",
                table: "Ciudades",
                column: "ProvinciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
