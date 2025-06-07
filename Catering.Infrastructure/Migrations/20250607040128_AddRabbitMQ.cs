using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRabbitMQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("75afd017-50b3-4feb-9aa1-6a0cc574da16"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("779f2031-c59a-4d99-a579-3b30fbc9d454"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("85c16f52-56c3-4dba-ad45-ea4f5fe47cc4"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("d390daf8-4432-4789-8620-a3f40713dfe4"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("1e055008-742c-4c3b-901b-f371156bfead"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("47eda952-9d17-45e6-a91d-7126290d8912"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("840c14b1-2aab-44b5-ba2e-336a17a4c38c"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("880fabc1-fc37-4940-8126-45f4ea076c00"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("99d49146-f040-4f66-b86b-237fec692687"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("9b37bd7e-4cf2-4a38-b9bf-cc047d6d52c1"));

            migrationBuilder.EnsureSchema(
                name: "outbox");

            migrationBuilder.CreateTable(
                name: "outboxMessage",
                schema: "outbox",
                columns: table => new
                {
                    outboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    processed = table.Column<bool>(type: "bit", nullable: false),
                    processedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    correlationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    traceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    spanId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outboxMessage", x => x.outboxId);
                });

            migrationBuilder.CreateTable(
                name: "PlanAlimentario",
                columns: table => new
                {
                    IdPlanAlimentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CantidadDias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAlimentario", x => x.IdPlanAlimentario);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    IdContrato = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPlanAlimentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiasContratados = table.Column<int>(type: "int", nullable: false),
                    DiasRealizados = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimoRealizado = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.IdContrato);
                    table.ForeignKey(
                        name: "FK_Contrato_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Contrato_PlanAlimentario_IdPlanAlimentario",
                        column: x => x.IdPlanAlimentario,
                        principalTable: "PlanAlimentario",
                        principalColumn: "IdPlanAlimentario");
                });

            migrationBuilder.CreateTable(
                name: "PlanAlimentarioReceta",
                columns: table => new
                {
                    IdPlanAlimentarioReceta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPlanAlimentario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdReceta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanAlimentarioReceta", x => x.IdPlanAlimentarioReceta);
                    table.ForeignKey(
                        name: "FK_PlanAlimentarioReceta_PlanAlimentario_IdPlanAlimentario",
                        column: x => x.IdPlanAlimentario,
                        principalTable: "PlanAlimentario",
                        principalColumn: "IdPlanAlimentario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanAlimentarioReceta_Receta_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Receta",
                        principalColumn: "IdReceta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContratoEntregaCancelada",
                columns: table => new
                {
                    IdContratoEntregaCancelada = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdContrato = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCancelada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratoEntregaCancelada", x => x.IdContratoEntregaCancelada);
                    table.ForeignKey(
                        name: "FK_ContratoEntregaCancelada_Contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalTable: "Contrato",
                        principalColumn: "IdContrato");
                });

            migrationBuilder.InsertData(
                table: "RecetaIngrediente",
                columns: new[] { "IdRecetaIngrediente", "Cantidad", "Detalle", "IdIngrediente", "IdReceta" },
                values: new object[,]
                {
                    { new Guid("01b0110b-61c8-4801-99c0-3620fdc0296b"), 2.0, "", new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("11d9ae1f-038b-4333-8be8-d63671975023"), 1.0, "", new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("6c422826-7f4e-4f8c-9121-4e82f1b6507a"), 1.0, "", new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("7cd951f4-3dbc-4722-8ef0-aab8d56f0bb7"), 2.0, "", new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") }
                });

            migrationBuilder.InsertData(
                table: "RecetaInstruccion",
                columns: new[] { "IdRecetaInstruccion", "IdReceta", "Instruccion" },
                values: new object[,]
                {
                    { new Guid("00a5eaac-15a9-4347-9179-6042e567f421"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "Instruccion 1" },
                    { new Guid("2205017b-20db-4522-b6b2-1046d188a702"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "Instruccion 2" },
                    { new Guid("2ab2f382-8685-46a4-bc14-51f724a9b812"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "Instruccion 3" },
                    { new Guid("76ff085d-2da7-4bb9-bcce-f9f7ccce1f79"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "Instruccion 1" },
                    { new Guid("b2ef0456-2e9a-4f36-9ce0-064c5265e3d6"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "Instruccion 2" },
                    { new Guid("b34b4bcc-2476-4c71-a961-0b448ce5cdc8"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "Instruccion 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdCliente",
                table: "Contrato",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdPlanAlimentario",
                table: "Contrato",
                column: "IdPlanAlimentario");

            migrationBuilder.CreateIndex(
                name: "IX_ContratoEntregaCancelada_IdContrato",
                table: "ContratoEntregaCancelada",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_PlanAlimentarioReceta_IdPlanAlimentario",
                table: "PlanAlimentarioReceta",
                column: "IdPlanAlimentario");

            migrationBuilder.CreateIndex(
                name: "IX_PlanAlimentarioReceta_IdReceta",
                table: "PlanAlimentarioReceta",
                column: "IdReceta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContratoEntregaCancelada");

            migrationBuilder.DropTable(
                name: "outboxMessage",
                schema: "outbox");

            migrationBuilder.DropTable(
                name: "PlanAlimentarioReceta");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "PlanAlimentario");

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("01b0110b-61c8-4801-99c0-3620fdc0296b"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("11d9ae1f-038b-4333-8be8-d63671975023"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("6c422826-7f4e-4f8c-9121-4e82f1b6507a"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("7cd951f4-3dbc-4722-8ef0-aab8d56f0bb7"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("00a5eaac-15a9-4347-9179-6042e567f421"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("2205017b-20db-4522-b6b2-1046d188a702"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("2ab2f382-8685-46a4-bc14-51f724a9b812"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("76ff085d-2da7-4bb9-bcce-f9f7ccce1f79"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("b2ef0456-2e9a-4f36-9ce0-064c5265e3d6"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("b34b4bcc-2476-4c71-a961-0b448ce5cdc8"));

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
        }
    }
}
