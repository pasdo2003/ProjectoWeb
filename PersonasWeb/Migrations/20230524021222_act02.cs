using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEBodyPlanet.Migrations
{
    /// <inheritdoc />
    public partial class act02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id_Categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id_Marca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomnbreMarca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id_Marca);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id_Proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cuit_proveedor = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CiudadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id_Proveedor);
                    table.ForeignKey(
                        name: "FK_Proveedor_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "Id_Ciudad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrecioVta1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVta2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaVto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarcaProductoId_Marca = table.Column<int>(type: "int", nullable: false),
                    Proveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    proveedorId_Proveedor = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoriaId_Categoria = table.Column<int>(type: "int", nullable: false),
                    Uso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id_Producto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_categoriaId_Categoria",
                        column: x => x.categoriaId_Categoria,
                        principalTable: "Categoria",
                        principalColumn: "Id_Categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Marca_MarcaProductoId_Marca",
                        column: x => x.MarcaProductoId_Marca,
                        principalTable: "Marca",
                        principalColumn: "Id_Marca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor_proveedorId_Proveedor",
                        column: x => x.proveedorId_Proveedor,
                        principalTable: "Proveedor",
                        principalColumn: "Id_Proveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoriaId_Categoria",
                table: "Producto",
                column: "categoriaId_Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_MarcaProductoId_Marca",
                table: "Producto",
                column: "MarcaProductoId_Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_proveedorId_Proveedor",
                table: "Producto",
                column: "proveedorId_Proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_CiudadId",
                table: "Proveedor",
                column: "CiudadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
