using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Cantidad = table.Column<double>(type: "float", nullable: false)
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
                        principalColumn: "IdCliente");
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

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "Nombre" },
                values: new object[,]
                {
                    { new Guid("9b971b55-e539-4939-9240-825a48402329"), "Cliente 1" },
                    { new Guid("a71010c7-979b-4217-a899-c1c3d8179f4a"), "Cliente 2" }
                });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "IdIngrediente", "CostoCompra", "CostoVenta", "Medicion", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"), 10.0m, 15.0m, "kg", "Ingrediente 1", "Tipo 1" },
                    { new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), 5.0m, 8.0m, "litro", "Ingrediente 2", "Tipo 2" }
                });

            migrationBuilder.InsertData(
                table: "Receta",
                columns: new[] { "IdReceta", "Nombre" },
                values: new object[,]
                {
                    { new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "Receta 1" },
                    { new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "Receta 2" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Nombre" },
                values: new object[,]
                {
                    { new Guid("76084be0-b170-44e8-a302-a4b7b34927d6"), "Usuario cocinero 2" },
                    { new Guid("d19a0e52-cf2a-45cb-a99f-7343afb296b4"), "Usuario cocinero 1" }
                });

            migrationBuilder.InsertData(
                table: "RecetaIngrediente",
                columns: new[] { "IdRecetaIngrediente", "Cantidad", "Detalle", "IdIngrediente", "IdReceta" },
                values: new object[,]
                {
                    { new Guid("75afd017-50b3-4feb-9aa1-6a0cc574da16"), 1.0, "", new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("779f2031-c59a-4d99-a579-3b30fbc9d454"), 1.0, "", new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("85c16f52-56c3-4dba-ad45-ea4f5fe47cc4"), 2.0, "", new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("d390daf8-4432-4789-8620-a3f40713dfe4"), 2.0, "", new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") }
                });

            migrationBuilder.InsertData(
                table: "RecetaInstruccion",
                columns: new[] { "IdRecetaInstruccion", "IdReceta", "Instruccion" },
                values: new object[,]
                {
                    { new Guid("1e055008-742c-4c3b-901b-f371156bfead"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "Instruccion 3" },
                    { new Guid("47eda952-9d17-45e6-a91d-7126290d8912"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "Instruccion 2" },
                    { new Guid("840c14b1-2aab-44b5-ba2e-336a17a4c38c"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "Instruccion 1" },
                    { new Guid("880fabc1-fc37-4940-8126-45f4ea076c00"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "Instruccion 3" },
                    { new Guid("99d49146-f040-4f66-b86b-237fec692687"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "Instruccion 1" },
                    { new Guid("9b37bd7e-4cf2-4a38-b9bf-cc047d6d52c1"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "Instruccion 2" }
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
