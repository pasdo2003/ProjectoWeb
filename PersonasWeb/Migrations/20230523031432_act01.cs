using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEBodyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class act01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id_Ciudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodPostal = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id_Ciudad);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id_Persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI_Persona = table.Column<int>(type: "int", nullable: false),
                    Nombre_Persona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido_Persona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono_Persona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail_Persona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Domicilio_Persona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id_Ciudad = table.Column<int>(type: "int", nullable: false),
                    CiudadId_Ciudad = table.Column<int>(type: "int", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id_Persona);
                    table.ForeignKey(
                        name: "FK_Persona_Ciudad_CiudadId_Ciudad",
                        column: x => x.CiudadId_Ciudad,
                        principalTable: "Ciudad",
                        principalColumn: "Id_Ciudad");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CiudadId_Ciudad",
                table: "Persona",
                column: "CiudadId_Ciudad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Ciudad");
        }
    }
}
