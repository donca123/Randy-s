using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    IdCargo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCargo = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.IdCargo);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreCategoria = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DescripcionCategoria = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Nombres = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ApellidoP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ApellidoM = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Nombres = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ApellidoP = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ApellidoM = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Dni = table.Column<int>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    IdEmpleado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<int>(nullable: false),
                    IdCargo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargo",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreProducto = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioVenta = table.Column<double>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    IdCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comprobante",
                columns: table => new
                {
                    IdComprobante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaEmision = table.Column<DateTime>(nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    Igv = table.Column<decimal>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    IdCliente = table.Column<int>(nullable: false),
                    IdEmpleado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobante", x => x.IdComprobante);
                    table.ForeignKey(
                        name: "FK_Comprobante_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comprobante_Empleado_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleComprobante",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false),
                    IdComprobante = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleComprobante", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetalleComprobante_Comprobante_IdComprobante",
                        column: x => x.IdComprobante,
                        principalTable: "Comprobante",
                        principalColumn: "IdComprobante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleComprobante_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_IdCliente",
                table: "Comprobante",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobante_IdEmpleado",
                table: "Comprobante",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobante_IdComprobante",
                table: "DetalleComprobante",
                column: "IdComprobante");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleComprobante_IdProducto",
                table: "DetalleComprobante",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdCargo",
                table: "Empleado",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleComprobante");

            migrationBuilder.DropTable(
                name: "Comprobante");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
