using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FACTURA.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Proveedor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "HojaFactura",
                columns: table => new
                {
                    IdHojaFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojaFactura", x => x.IdHojaFactura);
                    table.ForeignKey(
                        name: "FK_HojaFactura_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Linea",
                columns: table => new
                {
                    IdLinea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    IdHojaFactura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea", x => x.IdLinea);
                    table.ForeignKey(
                        name: "FK_Linea_HojaFactura_IdHojaFactura",
                        column: x => x.IdHojaFactura,
                        principalTable: "HojaFactura",
                        principalColumn: "IdHojaFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HojaFactura_IdCliente",
                table: "HojaFactura",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Linea_IdHojaFactura",
                table: "Linea",
                column: "IdHojaFactura");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linea");

            migrationBuilder.DropTable(
                name: "HojaFactura");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
