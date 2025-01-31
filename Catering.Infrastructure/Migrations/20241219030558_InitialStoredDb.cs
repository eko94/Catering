using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStoredDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    IdIngrediente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Medicion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CostoCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.IdIngrediente);
                });

            migrationBuilder.CreateTable(
                name: "Receta",
                columns: table => new
                {
                    IdReceta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receta", x => x.IdReceta);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "RecetaIngrediente",
                columns: table => new
                {
                    IdRecetaIngrediente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdReceta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdIngrediente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaIngrediente", x => x.IdRecetaIngrediente);
                    table.ForeignKey(
                        name: "FK_RecetaIngrediente_Ingrediente_IdIngrediente",
                        column: x => x.IdIngrediente,
                        principalTable: "Ingrediente",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetaIngrediente_Receta_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Receta",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetaInstruccion",
                columns: table => new
                {
                    IdRecetaInstruccion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdReceta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Instruccion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaInstruccion", x => x.IdRecetaInstruccion);
                    table.ForeignKey(
                        name: "FK_RecetaInstruccion_Receta_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Receta",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajo",
                columns: table => new
                {
                    IdOrdenTrabajo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuarioCocinero = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdReceta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajo", x => x.IdOrdenTrabajo);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajo_Receta_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Receta",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajo_Usuario_IdUsuarioCocinero",
                        column: x => x.IdUsuarioCocinero,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comida",
                columns: table => new
                {
                    IdComida = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdOrdenTrabajo = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comida", x => x.IdComida);
                    table.ForeignKey(
                        name: "FK_Comida_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comida_OrdenTrabajo_IdOrdenTrabajo",
                        column: x => x.IdOrdenTrabajo,
                        principalTable: "OrdenTrabajo",
                        principalColumn: "IdOrdenTrabajo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenTrabajoCliente",
                columns: table => new
                {
                    IdOrdenTrabajoCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdOrdenTrabajo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenTrabajoCliente", x => x.IdOrdenTrabajoCliente);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajoCliente_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenTrabajoCliente_OrdenTrabajo_IdOrdenTrabajo",
                        column: x => x.IdOrdenTrabajo,
                        principalTable: "OrdenTrabajo",
                        principalColumn: "IdOrdenTrabajo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comida_IdCliente",
                table: "Comida",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Comida_IdOrdenTrabajo",
                table: "Comida",
                column: "IdOrdenTrabajo");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajo_IdReceta",
                table: "OrdenTrabajo",
                column: "IdReceta");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajo_IdUsuarioCocinero",
                table: "OrdenTrabajo",
                column: "IdUsuarioCocinero");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajoCliente_IdCliente",
                table: "OrdenTrabajoCliente",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajoCliente_IdOrdenTrabajo",
                table: "OrdenTrabajoCliente",
                column: "IdOrdenTrabajo");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngrediente_IdIngrediente",
                table: "RecetaIngrediente",
                column: "IdIngrediente");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaIngrediente_IdReceta",
                table: "RecetaIngrediente",
                column: "IdReceta");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaInstruccion_IdReceta",
                table: "RecetaInstruccion",
                column: "IdReceta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comida");

            migrationBuilder.DropTable(
                name: "OrdenTrabajoCliente");

            migrationBuilder.DropTable(
                name: "RecetaIngrediente");

            migrationBuilder.DropTable(
                name: "RecetaInstruccion");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "OrdenTrabajo");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Receta");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
