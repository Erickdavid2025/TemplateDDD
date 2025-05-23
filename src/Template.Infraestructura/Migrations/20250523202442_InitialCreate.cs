using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Template.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EsCuentaPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    CuentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimientos_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Jose Ramon" },
                    { 2, "Hernan Perez" },
                    { 3, "Ramon Castro" },
                    { 4, "Alex Rodriguez" }
                });

            migrationBuilder.InsertData(
                table: "Cuentas",
                columns: new[] { "Id", "ClienteId", "EsCuentaPrincipal", "Saldo" },
                values: new object[,]
                {
                    { 101, 1, true, 157500.25m },
                    { 102, 1, false, 25300.75m },
                    { 103, 2, true, 80200.00m },
                    { 104, 3, false, 80200.00m }
                });

            migrationBuilder.InsertData(
                table: "Tarjetas",
                columns: new[] { "Id", "CuentaId", "EsPrincipal", "Numero" },
                values: new object[,]
                {
                    { 1001, 101, true, "4509-8701-2345-6789" },
                    { 1002, 101, false, "4509-8701-2345-6789" },
                    { 2001, 103, true, "4510-2301-3345-1244" }
                });

            migrationBuilder.InsertData(
                table: "Movimientos",
                columns: new[] { "Id", "Descripcion", "Fecha", "Monto", "TarjetaId" },
                values: new object[,]
                {
                    { 1, "Compra supermercado", new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), -9500.00m, 1001 },
                    { 2, "Pago seguro auto", new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), -12000.00m, 1001 },
                    { 3, "Farmacia", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -6500.00m, 1001 },
                    { 4, "Electrodoméstico", new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), -43000.00m, 1001 },
                    { 5, "Spotify Premium", new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), -1999.00m, 1001 },
                    { 6, "Carga SUBE", new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), -1500.00m, 1001 },
                    { 7, "Compra secundaria", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), -3000.00m, 1002 },
                    { 8, "Cena en restaurante", new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), -7500.00m, 2001 },
                    { 9, "Pago Netflix", new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -3000.00m, 2001 },
                    { 10, "Compra electro", new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), -18000.00m, 2001 },
                    { 11, "Compra Carro", new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), -18000.00m, 2001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_ClienteId",
                table: "Cuentas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_TarjetaId",
                table: "Movimientos",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_CuentaId",
                table: "Tarjetas",
                column: "CuentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
