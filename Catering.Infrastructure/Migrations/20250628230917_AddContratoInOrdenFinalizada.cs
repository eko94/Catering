using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContratoInOrdenFinalizada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comida_OrdenTrabajo_IdOrdenTrabajo",
                table: "Comida");

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("166a1ed5-daef-4475-9c7f-ec25dbb2b33f"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("3028a30f-d3b4-47f4-af18-0f89324fffbe"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("30e45c75-bf1f-4341-b4ae-03b8cee6e789"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("3f5d575b-15fe-415b-a697-60e234f7f52c"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("3fffac45-8a06-4556-bda9-8fca0eccf11b"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("40c0485a-9790-4c68-8a31-f2041485c895"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("486738dd-3b9c-48bd-ba60-aeeec60d7c8f"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("59cdbb6f-68e7-494b-bc5d-41b860e0e60c"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("5ab78f81-87d2-498e-94f1-231aa8dfa5bf"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("5b7d3848-9e4a-4063-8861-41d234f2381d"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("6160026e-9a9f-482b-8afb-7ac04dd55c15"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("65548f1b-feba-40e0-8a91-a363319c9041"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("6e392090-fd95-4405-ac36-409ec4759a42"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("716b380b-1bee-4629-b09e-9f1ba06a7f97"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("72db7bc6-a6d6-4f11-864c-8f382a2c266d"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("8195bdbc-00a0-4917-8ce5-8dc0986106c2"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("84072b97-77c9-4ccb-9b9b-d29ede40db54"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("93127af8-53be-4935-a33a-44c8bf6d6fea"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("9742cbf8-4db4-4605-9c6f-e9fada719add"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("9cb5baaa-1c99-4101-81f9-3ced1057b715"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("9e874ca6-76dd-41d1-bbf3-809585eb29ae"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("a8fffd2d-4255-47ef-a0e8-8922d5178b32"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("ac457561-0556-4c8b-a886-9b6e095cfcc1"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("ad97edc6-71fd-44d9-ae11-b9cca918308b"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("b4030821-5d3d-48b9-b19c-4d0b741717a8"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("b913dea9-e201-42d5-b800-7d8ee5269245"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("baff6777-24ab-49ea-9433-0514ffd94f6f"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("bfc9ca35-e128-4e40-abbe-b1877bd1b3d4"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("c31db85c-e0bb-4497-92d1-06be898bfcb7"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("c8fff2ed-f9bd-4784-b37d-98001112329a"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("db320652-02b5-4b56-b27f-1b1ce746e6f3"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("dd0ec80c-ccd2-412e-bcd9-d91c3b8253e2"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("e2b2ece3-d813-4414-a72f-77e35f54c1dc"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("eaba08a6-c753-43f8-b9db-5d7ea87eb839"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("fbd088e2-e31b-4b08-b2d8-5e8f35bfa6be"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("0413cadb-11f8-40ee-82bd-3519d20233a7"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("0476c087-ae00-4995-bef4-b1bb5622ae35"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("0d6464de-cb60-4ab2-b996-12bb3efac8cd"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("0ed37ae3-7200-4f57-a9a3-926af7723a30"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("0eeaa4e4-f78a-40ac-b4bd-f9675e859ca3"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("1f820b52-f93c-4494-a466-9dbe9b9f4173"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("287aa52a-1cd7-46c2-ab20-b2881904623b"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("30ff4ce5-06b5-45e1-84c6-8a941588fcd5"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("37e39156-d452-406f-a968-9329a3d2fbfe"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("47522d10-132b-4e1e-8e62-e0504f3383f5"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("490efb22-ea42-4357-a52e-32144bcffeec"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("59939db8-0718-4049-add9-fd34fb96e0c1"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("59a7382e-7091-4ff1-9e69-38daaee7f6d6"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("83af7ebe-12e0-447e-a4c6-65ab24f18c0c"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("b857ef2b-5cd6-495d-8b89-a027136d5daf"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("bcc129e2-d309-4828-82c7-edb1b9613c39"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("c1bc7018-0d4a-4901-b447-ba2e42fa9e64"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("c3d6adb5-71c3-4d26-a516-fb2d6147918c"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("ceb44330-9b85-4864-9704-3cbcc80d2324"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("d36861c3-4df9-485e-b896-0ed3f12ee29f"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("d38600da-f740-4e0a-949f-a5bab086840f"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("ddd33118-7eb5-42d0-8bd9-571aa00c7983"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("deb42c99-787c-4051-bf2c-7428e56940f3"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("e20d1170-072b-4697-8626-b108849d4001"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("e2a8025e-8ded-41e6-ba08-8d5152d95808"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("e3b91da5-e0f6-4fd6-905c-b17b76c817c2"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("e54802df-bec4-4fd7-9570-d7c79c19b30f"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("eb4ff17c-eae8-4569-b535-aeff70903141"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("f27a3e6e-a4b5-4a5a-88a2-67ae0f2a346e"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("f4c716df-d287-43c1-a3e2-ffb7dd1bc698"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("fd0b4eef-c47b-429d-92c6-2a84027ffd92"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("06039340-c688-4198-be53-9b121b8b6095"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("0745f464-037e-480b-be23-03e496455b07"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("0e2c4760-659c-461b-b5a4-625f977006bb"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("12aa9ee3-bd3c-484c-a884-3e3c15f41ead"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("19463210-1541-4657-b434-40cbbe632ad0"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("2c769505-6d43-4c97-b41f-932ad482e392"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("2dac2664-b05a-4d3d-a1fb-6484cf974040"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("3118439c-0fed-48f2-8360-7aa88c54c5fc"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("32f0b892-9b46-422e-b150-0371fcd53c3a"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("3ed4a2b6-0e34-42f8-a09a-6ea9c7cc4cd7"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("44b773af-e296-4e3c-b14d-e2666a9ec9d0"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("4dabd6cb-1f9b-472d-af4d-b4d33a8f5b05"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("4db4c7f2-d408-4cd0-9158-1274da111e09"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("56b8e3f1-1d7f-4def-9701-5c1897d615bf"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("57926f10-5803-45f6-91f0-17d0da6da8d9"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("5c6f43b5-4cea-44a8-bd2f-a9b10d2d8767"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("67187905-2b25-4506-a130-80a27c14657a"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("6a5749df-d4dc-41c0-b6ab-8695818fc9e6"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("70b99e59-1771-4e65-8089-ffac97b1d6f3"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("77fe8568-533f-44dd-b1bf-945e688ecd3a"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("7e976679-6260-4ddc-bdaf-1893f97b49a2"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("8086a17c-8982-46e2-ac9b-1daaeb851511"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("86c608c6-a760-45c1-a0fd-3f5be3e80e0f"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("98984a30-ca54-409b-8414-5d63f874990b"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("9e2a9322-8141-4217-9676-f0854e6be3bb"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("ab285967-94c6-48a2-b66d-42971e3054ae"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("b0a2dd75-e553-4449-8361-4fdde9dd5cd9"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("d8b1ac8c-ff87-4f98-bb99-01a74e468068"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("defe0a39-59e9-4700-85b1-fbcfd707ecd8"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("df14fcb6-b47c-4a1e-b168-fea14acd34e9"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("ec8e74f0-0374-458d-bddf-aca570199fdf"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("eeb37d25-bed5-47df-895b-d1d71991ba41"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("f81da1c8-3a09-435a-98bd-a57f01c4bd88"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("fa650ba6-9eaa-4f17-96a4-4a389587e958"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("fec95a30-bf71-431e-867e-8e772ba4111e"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdContrato",
                table: "OrdenTrabajoCliente",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "IdOrdenTrabajo",
                table: "Comida",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "IdContrato",
                table: "Comida",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "IdIngrediente", "CostoCompra", "CostoVenta", "Medicion", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { new Guid("01b72770-ae8c-4388-9a18-cfd640e1d8c8"), 5.0m, 8.0m, "kg", "Queso parmesano", "Fruta" },
                    { new Guid("07e45ecc-4ed6-4372-bf7f-44f00ccca281"), 5.0m, 8.0m, "kg", "Huevo", "Fruta" },
                    { new Guid("0f05cab9-29e6-4925-8e81-1260aa818163"), 10.0m, 15.0m, "kg", "Brócoli", "Verdura" },
                    { new Guid("1ba2a2b1-d3b4-44e3-844d-823eae6c8411"), 5.0m, 8.0m, "kg", "Tomillo", "Fruta" },
                    { new Guid("2f270869-7d88-4607-b394-db1f84c55322"), 5.0m, 8.0m, "lt", "Caldo de pollo bajo en sodio", "Fruta" },
                    { new Guid("35d116a9-83bd-49ae-a238-efb9070ca882"), 5.0m, 8.0m, "litro", "Aceite de oliva", "Aceite" },
                    { new Guid("3ca2ff52-e9c6-4c31-bc4e-9b2cd28049ef"), 5.0m, 8.0m, "kg", "Calabaza", "Fruta" },
                    { new Guid("3dcd17d6-5ce4-4c9d-8c1f-f61a96a45954"), 5.0m, 8.0m, "kg", "Limón", "Fruta" },
                    { new Guid("55f73b90-e5c0-4153-9f4c-b5b688544da3"), 5.0m, 8.0m, "kg", "Huevos", "Fruta" },
                    { new Guid("582b7a4d-541b-4021-9b7b-8dbdbf73342e"), 5.0m, 8.0m, "kg", "Zanahoria", "Fruta" },
                    { new Guid("586963c6-d514-4789-8e6a-0055b7fed7cd"), 5.0m, 8.0m, "kg", "Puerro", "Fruta" },
                    { new Guid("5c795374-da7d-4a04-ad2d-65a2c9aa66b9"), 5.0m, 8.0m, "kg", "Pan integral", "Fruta" },
                    { new Guid("7cc521ec-495e-4a08-9e46-2f226ddc4979"), 5.0m, 8.0m, "kg", "Langostinos", "Fruta" },
                    { new Guid("7e5b6430-1dff-4a4f-8c0d-60f37d87f1e7"), 5.0m, 8.0m, "kg", "Pimiento verde", "Fruta" },
                    { new Guid("84c48d2c-842d-4b0d-8c9b-3264499f0f0f"), 5.0m, 8.0m, "kg", "Sal", "Fruta" },
                    { new Guid("8b8b18b3-3783-415b-a6f8-09d53a8d4dfc"), 5.0m, 8.0m, "kg", "Jengibre fresco", "Fruta" },
                    { new Guid("9088fd3a-e9d2-4583-a02a-f57c075cfe9c"), 5.0m, 8.0m, "kg", "Pechuga de pollo", "Fruta" },
                    { new Guid("93cabbc2-39a2-491e-a10d-7a1ca5fbf844"), 5.0m, 8.0m, "kg", "Zanahoria", "Verdura" },
                    { new Guid("9748fd84-f80f-4e23-9aa4-74ca5a508be3"), 5.0m, 8.0m, "kg", "Palta", "Fruta" },
                    { new Guid("975049c9-74e8-42d1-a94f-5faf49b8590f"), 5.0m, 8.0m, "kg", "Brócoli", "Fruta" },
                    { new Guid("9d77a61e-4404-4f08-ae91-6bbdc1ab4d46"), 5.0m, 8.0m, "kg", "Cebolla", "Fruta" },
                    { new Guid("a2049b76-cd7f-4bf6-a44f-90117fc7d7da"), 5.0m, 8.0m, "kg", "Almendras", "Fruta" },
                    { new Guid("a2c4c8b3-3209-4a28-aa2c-520101a95ee2"), 5.0m, 8.0m, "kg", "Zanahoria", "Fruta" },
                    { new Guid("a934eaab-d760-4151-9f10-7041151768e7"), 5.0m, 8.0m, "kg", "Calabacín", "Fruta" },
                    { new Guid("ae4502e0-c112-43f8-abd0-eaa0e5e2e707"), 5.0m, 8.0m, "kg", "Hierbas frescas", "Fruta" },
                    { new Guid("b0810fd3-fbbc-4e09-a842-f166d0e02003"), 10.0m, 15.0m, "kg", "Fideos", "Verdura" },
                    { new Guid("bb206655-96ff-4933-a915-32bfc788a345"), 5.0m, 8.0m, "kg", "Cuscús", "Fruta" },
                    { new Guid("c0865709-e77d-427a-bb00-f10d83de6a6f"), 5.0m, 8.0m, "kg", "Nueces", "Fruta" },
                    { new Guid("c5a5a200-b9aa-4ef8-b631-e959c325b5cb"), 5.0m, 8.0m, "litro", "Ajo", "Aceite" },
                    { new Guid("c957043d-fdd7-41e2-8943-d847f2b56d60"), 5.0m, 8.0m, "kg", "Aceite de oliva", "Fruta" },
                    { new Guid("d0061839-d9ad-46ba-afea-d0616dbca20f"), 5.0m, 8.0m, "kg", "Lentejas", "Fruta" },
                    { new Guid("ddb6572c-f24c-48cd-985e-d81442db791f"), 5.0m, 8.0m, "kg", "Apio", "Fruta" },
                    { new Guid("e6b8015b-afde-42c1-b9f8-85287f5cfe7c"), 5.0m, 8.0m, "kg", "Cúrcuma", "Fruta" },
                    { new Guid("e833429e-daee-4a9a-8625-cd0fef7d495d"), 5.0m, 8.0m, "kg", "Cebolla", "Fruta" },
                    { new Guid("e991e259-b090-4db7-bf72-c1782d9c32ee"), 5.0m, 8.0m, "kg", "Hongos", "Verdura" }
                });

            migrationBuilder.InsertData(
                table: "PlanAlimentario",
                columns: new[] { "IdPlanAlimentario", "CantidadDias", "Nombre", "Tipo" },
                values: new object[] { new Guid("b1c8f0d2-3c4e-4f5a-9b6c-7d8e9f0a1b2c"), 15, "Plan Alimentario Test", "Tipo del plan alimentario test" });

            migrationBuilder.InsertData(
                table: "RecetaInstruccion",
                columns: new[] { "IdRecetaInstruccion", "IdReceta", "Instruccion" },
                values: new object[,]
                {
                    { new Guid("0494c609-c170-445e-8245-ccb41b8ca446"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "3. Agrega el pimiento, calabacín y pollo troceado." },
                    { new Guid("04cb1dd9-7489-46d3-a682-706eb3f1845e"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "5. Incorpora los huevos batidos y revuelve hasta que cuajen." },
                    { new Guid("0bbb3d4d-9ade-4751-b831-87594db71991"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "3. Agrega el resto de las verduras y cocina por 5 minutos." },
                    { new Guid("100bebed-e933-40c6-b81a-ce31f9aa5a38"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "1. Cocina el brócoli en agua con sal durante 5 minutos." },
                    { new Guid("1c919f00-4e8e-40b3-accc-ecf250542e85"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "4. Añade los langostinos y cocina hasta que estén dorados." },
                    { new Guid("276fb00e-89a2-44e9-8f80-172ac6268557"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "2. Saltea la cebolla y el puerro en una olla con aceite." },
                    { new Guid("2c9a25fc-1ef1-4ba6-b0c0-f5b5ba507e00"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "2. Ralla la zanahoria y mézclala con el brócoli." },
                    { new Guid("3997d976-c7db-4913-9b45-508a92eb8137"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "3. Aliña con aceite de oliva y sal." },
                    { new Guid("3d0377e8-fbf3-4184-a1c7-9126a06bdd13"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "3. Agrega los hongos y saltéalos por 10 minutos." },
                    { new Guid("430ab4ab-0cac-4a4c-8898-6d276c9060f4"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "2. Saltea la cebolla picada hasta que esté dorada." },
                    { new Guid("48b249bb-a41c-4475-b79b-652eaa018088"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "5. Cocina a fuego lento por 15 minutos y cuela el caldo." },
                    { new Guid("4d6f0cb5-3fc0-4fe3-b7b9-5fc104fc8855"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "1. Cocina los fideos en agua hirviendo." },
                    { new Guid("53161d8e-0570-4766-a3f0-f3d4335d933a"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "1. Pela y corta las verduras en trozos pequeños." },
                    { new Guid("5bc31749-9881-4d75-931e-c354d5bdb1e7"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "4. Pica las nueces y agrégalas a la ensalada." },
                    { new Guid("6a62ea62-2e0e-43ec-bb26-9d4cd5da0948"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "4. Cocina hasta que el pollo esté bien cocido." },
                    { new Guid("7232ec6e-8b08-4010-afc3-60c57dc28099"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "1. Cocina la calabaza y mézclala con las lentejas." },
                    { new Guid("904af092-33b4-44bf-a4f3-ee651d745e65"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "2. Agrega la cebolla y zanahoria picadas y sofríe por unos minutos." },
                    { new Guid("a958abfc-674a-4c0b-95c1-6e8527af6427"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "3. Cocina el huevo escalfado y colócalo encima." },
                    { new Guid("ab9ae51a-d382-4628-a5be-90e7b297273b"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "1. Tuesta el pan integral." },
                    { new Guid("accf184a-685e-4e69-a22f-d3aabbb0b66d"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "5. Mezcla con el cuscús y espolvorea cúrcuma." },
                    { new Guid("b8d7dda8-5548-45e2-9b8d-dc644c0da0c5"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "4. Sirve con hummus por encima." },
                    { new Guid("bc89fd25-9af3-46fd-a1da-51d9b929218e"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "4. Incorpora el brócoli y el jengibre rallado. Cocina por 10 minutos." },
                    { new Guid("cd67cc06-a8c0-4c71-956e-53234dd9f37e"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "2. Machaca la palta y úntala sobre el pan." },
                    { new Guid("d86b8da3-21ad-460f-b511-1434b7e334ca"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "4. Añade agua y hierbas aromáticas." },
                    { new Guid("d9a8ba77-5d0e-4ae7-8b7b-44bd15a12feb"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "1. Cocina el cuscús según las instrucciones del paquete." },
                    { new Guid("e0484bba-57b1-4eae-a826-6d5f676bc37d"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "3. Prepara una vinagreta con aceite de oliva y limón." },
                    { new Guid("e312e47c-d922-4ce9-87f2-a133c67ca046"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "3. Añade el caldo de pollo y deja hervir." },
                    { new Guid("e4d71b9d-fc15-475f-a990-dc53948e304d"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "1. Cocina el pollo en una cacerola con un poco de aceite hasta dorarlo." },
                    { new Guid("e5720887-3f4e-4f49-828a-c0945d4b03a0"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "2. Pica las almendras y agrégalas." },
                    { new Guid("ec01f0db-b0cc-4295-b442-b797c3dc47df"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "4. Espolvorea queso parmesano y hierbas frescas." },
                    { new Guid("ef558fe6-99d5-41c3-b59c-d3795faba4ec"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "2. Dora el ajo en una sartén con aceite." }
                });

            migrationBuilder.InsertData(
                table: "Contrato",
                columns: new[] { "IdContrato", "DiasContratados", "DiasRealizados", "Estado", "FechaInicio", "FechaUltimoRealizado", "IdCliente", "IdPlanAlimentario" },
                values: new object[] { new Guid("5faf7842-e7b5-4a3f-96c8-7719d01748b9"), 15, 0, "Iniciado", new DateTime(2025, 6, 28, 0, 0, 0, 0, DateTimeKind.Local), null, new Guid("9b971b55-e539-4939-9240-825a48402329"), new Guid("b1c8f0d2-3c4e-4f5a-9b6c-7d8e9f0a1b2c") });

            migrationBuilder.InsertData(
                table: "RecetaIngrediente",
                columns: new[] { "IdRecetaIngrediente", "Cantidad", "Detalle", "IdIngrediente", "IdReceta" },
                values: new object[,]
                {
                    { new Guid("024295a8-ee8d-4d68-95ad-29a6a530f804"), 1.0, "", new Guid("0f05cab9-29e6-4925-8e81-1260aa818163"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("0f41312d-5374-40be-998b-c2bf1e6439ac"), 1.0, "", new Guid("ae4502e0-c112-43f8-abd0-eaa0e5e2e707"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("17fbfe8a-58aa-4330-8d9c-ffd86e058380"), 2.0, "", new Guid("3dcd17d6-5ce4-4c9d-8c1f-f61a96a45954"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("1a809aa1-bfd1-4c5e-bbc7-9ad0f99c9561"), 2.0, "", new Guid("9d77a61e-4404-4f08-ae91-6bbdc1ab4d46"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("1d440379-abff-48bf-b3fe-2be1f2bc7ea1"), 1.0, "", new Guid("2f270869-7d88-4607-b394-db1f84c55322"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("1e930973-4336-4866-9943-8c47a29ad462"), 2.0, "", new Guid("ddb6572c-f24c-48cd-985e-d81442db791f"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("1f08902e-539d-4bf1-98df-631f194f445d"), 1.0, "", new Guid("3ca2ff52-e9c6-4c31-bc4e-9b2cd28049ef"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("2377e2de-6966-434c-9fbb-2206c0eafebc"), 0.5, "", new Guid("975049c9-74e8-42d1-a94f-5faf49b8590f"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("326e4375-ee15-45f6-b005-2304c61a81c2"), 1.0, "", new Guid("35d116a9-83bd-49ae-a238-efb9070ca882"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("426c988f-5929-4819-a81e-17cf6d7c130c"), 1.0, "", new Guid("9748fd84-f80f-4e23-9aa4-74ca5a508be3"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("4578a298-7e95-4990-8852-3477bf92cc9c"), 2.0, "", new Guid("7cc521ec-495e-4a08-9e46-2f226ddc4979"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("6a91ff7c-827e-417a-9f4b-06b7d5aad185"), 0.5, "", new Guid("a2049b76-cd7f-4bf6-a44f-90117fc7d7da"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("6f700eb6-4c1b-474a-9577-eb6d53720e45"), 0.5, "", new Guid("586963c6-d514-4789-8e6a-0055b7fed7cd"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("70b624f9-c252-4031-8b55-9cecf0b7fc01"), 2.0, "", new Guid("bb206655-96ff-4933-a915-32bfc788a345"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("72e7875e-642b-4645-9541-6621d38ee57a"), 2.0, "", new Guid("5c795374-da7d-4a04-ad2d-65a2c9aa66b9"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("793e85e4-553c-4f28-a9d0-0afc376cb185"), 2.0, "", new Guid("d0061839-d9ad-46ba-afea-d0616dbca20f"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("7dc93e3d-2538-494a-abb1-a71552bea199"), 1.0, "", new Guid("93cabbc2-39a2-491e-a10d-7a1ca5fbf844"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("85965ca5-55ba-4f19-99a9-a72cb3837aa2"), 0.5, "", new Guid("7e5b6430-1dff-4a4f-8c0d-60f37d87f1e7"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("881b7716-ef49-4d19-b13b-faccbf8a33ea"), 1.0, "", new Guid("a2c4c8b3-3209-4a28-aa2c-520101a95ee2"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("8abc08f4-3959-45dc-874b-74c035c09173"), 1.0, "", new Guid("e6b8015b-afde-42c1-b9f8-85287f5cfe7c"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("9272e1cd-5f09-44ee-abd4-ddbafc9bf0b4"), 1.0, "", new Guid("b0810fd3-fbbc-4e09-a842-f166d0e02003"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("9647c2c6-b72d-4f3b-b2ea-3a3b1b3887e0"), 1.0, "", new Guid("a934eaab-d760-4151-9f10-7041151768e7"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("a3ed9326-30d1-42f9-b0bb-3647487a2055"), 1.0, "", new Guid("8b8b18b3-3783-415b-a6f8-09d53a8d4dfc"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("a76a0673-22de-4686-a912-634e775d3834"), 1.0, "", new Guid("01b72770-ae8c-4388-9a18-cfd640e1d8c8"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("aa265174-8580-49ab-9a78-6ce010666833"), 2.0, "", new Guid("c0865709-e77d-427a-bb00-f10d83de6a6f"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("b792dc4b-48fa-4d2a-81fb-30b0f2e006f5"), 1.0, "", new Guid("c957043d-fdd7-41e2-8943-d847f2b56d60"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("c2b7d7cb-7797-4ce2-b2cd-e2eebd367045"), 1.0, "", new Guid("582b7a4d-541b-4021-9b7b-8dbdbf73342e"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("c8c8451f-d087-4c79-af03-a84efe53d048"), 1.0, "", new Guid("1ba2a2b1-d3b4-44e3-844d-823eae6c8411"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("cff5519c-aac0-4156-9610-6efec7c5eda1"), 1.0, "", new Guid("9088fd3a-e9d2-4583-a02a-f57c075cfe9c"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("d00f5d67-5cf2-459f-b3f5-e1630958f9a0"), 1.0, "", new Guid("84c48d2c-842d-4b0d-8c9b-3264499f0f0f"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("d170edb5-bbaf-4edf-afe5-d2a8c05d380f"), 1.0, "", new Guid("55f73b90-e5c0-4153-9f4c-b5b688544da3"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("d9f48ffb-2348-49da-a5e3-e2a7e20c2ef5"), 0.5, "", new Guid("07e45ecc-4ed6-4372-bf7f-44f00ccca281"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("e672b853-0453-4c82-b709-38a45e860337"), 1.0, "", new Guid("c5a5a200-b9aa-4ef8-b631-e959c325b5cb"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("ea250c7d-630c-4dfe-b77e-141d8ccdd5ec"), 1.0, "", new Guid("e833429e-daee-4a9a-8625-cd0fef7d495d"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("f4e8350b-08cd-4cce-81c0-637f6bcb4af4"), 2.0, "", new Guid("e991e259-b090-4db7-bf72-c1782d9c32ee"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenTrabajoCliente_IdContrato",
                table: "OrdenTrabajoCliente",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_Comida_IdContrato",
                table: "Comida",
                column: "IdContrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Comida_Contrato_IdContrato",
                table: "Comida",
                column: "IdContrato",
                principalTable: "Contrato",
                principalColumn: "IdContrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Comida_OrdenTrabajo_IdOrdenTrabajo",
                table: "Comida",
                column: "IdOrdenTrabajo",
                principalTable: "OrdenTrabajo",
                principalColumn: "IdOrdenTrabajo");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenTrabajoCliente_Contrato_IdContrato",
                table: "OrdenTrabajoCliente",
                column: "IdContrato",
                principalTable: "Contrato",
                principalColumn: "IdContrato",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comida_Contrato_IdContrato",
                table: "Comida");

            migrationBuilder.DropForeignKey(
                name: "FK_Comida_OrdenTrabajo_IdOrdenTrabajo",
                table: "Comida");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenTrabajoCliente_Contrato_IdContrato",
                table: "OrdenTrabajoCliente");

            migrationBuilder.DropIndex(
                name: "IX_OrdenTrabajoCliente_IdContrato",
                table: "OrdenTrabajoCliente");

            migrationBuilder.DropIndex(
                name: "IX_Comida_IdContrato",
                table: "Comida");

            migrationBuilder.DeleteData(
                table: "Contrato",
                keyColumn: "IdContrato",
                keyValue: new Guid("5faf7842-e7b5-4a3f-96c8-7719d01748b9"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("024295a8-ee8d-4d68-95ad-29a6a530f804"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("0f41312d-5374-40be-998b-c2bf1e6439ac"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("17fbfe8a-58aa-4330-8d9c-ffd86e058380"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("1a809aa1-bfd1-4c5e-bbc7-9ad0f99c9561"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("1d440379-abff-48bf-b3fe-2be1f2bc7ea1"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("1e930973-4336-4866-9943-8c47a29ad462"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("1f08902e-539d-4bf1-98df-631f194f445d"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("2377e2de-6966-434c-9fbb-2206c0eafebc"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("326e4375-ee15-45f6-b005-2304c61a81c2"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("426c988f-5929-4819-a81e-17cf6d7c130c"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("4578a298-7e95-4990-8852-3477bf92cc9c"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("6a91ff7c-827e-417a-9f4b-06b7d5aad185"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("6f700eb6-4c1b-474a-9577-eb6d53720e45"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("70b624f9-c252-4031-8b55-9cecf0b7fc01"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("72e7875e-642b-4645-9541-6621d38ee57a"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("793e85e4-553c-4f28-a9d0-0afc376cb185"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("7dc93e3d-2538-494a-abb1-a71552bea199"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("85965ca5-55ba-4f19-99a9-a72cb3837aa2"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("881b7716-ef49-4d19-b13b-faccbf8a33ea"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("8abc08f4-3959-45dc-874b-74c035c09173"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("9272e1cd-5f09-44ee-abd4-ddbafc9bf0b4"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("9647c2c6-b72d-4f3b-b2ea-3a3b1b3887e0"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("a3ed9326-30d1-42f9-b0bb-3647487a2055"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("a76a0673-22de-4686-a912-634e775d3834"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("aa265174-8580-49ab-9a78-6ce010666833"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("b792dc4b-48fa-4d2a-81fb-30b0f2e006f5"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("c2b7d7cb-7797-4ce2-b2cd-e2eebd367045"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("c8c8451f-d087-4c79-af03-a84efe53d048"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("cff5519c-aac0-4156-9610-6efec7c5eda1"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("d00f5d67-5cf2-459f-b3f5-e1630958f9a0"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("d170edb5-bbaf-4edf-afe5-d2a8c05d380f"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("d9f48ffb-2348-49da-a5e3-e2a7e20c2ef5"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("e672b853-0453-4c82-b709-38a45e860337"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("ea250c7d-630c-4dfe-b77e-141d8ccdd5ec"));

            migrationBuilder.DeleteData(
                table: "RecetaIngrediente",
                keyColumn: "IdRecetaIngrediente",
                keyValue: new Guid("f4e8350b-08cd-4cce-81c0-637f6bcb4af4"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("0494c609-c170-445e-8245-ccb41b8ca446"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("04cb1dd9-7489-46d3-a682-706eb3f1845e"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("0bbb3d4d-9ade-4751-b831-87594db71991"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("100bebed-e933-40c6-b81a-ce31f9aa5a38"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("1c919f00-4e8e-40b3-accc-ecf250542e85"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("276fb00e-89a2-44e9-8f80-172ac6268557"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("2c9a25fc-1ef1-4ba6-b0c0-f5b5ba507e00"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("3997d976-c7db-4913-9b45-508a92eb8137"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("3d0377e8-fbf3-4184-a1c7-9126a06bdd13"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("430ab4ab-0cac-4a4c-8898-6d276c9060f4"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("48b249bb-a41c-4475-b79b-652eaa018088"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("4d6f0cb5-3fc0-4fe3-b7b9-5fc104fc8855"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("53161d8e-0570-4766-a3f0-f3d4335d933a"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("5bc31749-9881-4d75-931e-c354d5bdb1e7"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("6a62ea62-2e0e-43ec-bb26-9d4cd5da0948"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("7232ec6e-8b08-4010-afc3-60c57dc28099"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("904af092-33b4-44bf-a4f3-ee651d745e65"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("a958abfc-674a-4c0b-95c1-6e8527af6427"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("ab9ae51a-d382-4628-a5be-90e7b297273b"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("accf184a-685e-4e69-a22f-d3aabbb0b66d"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("b8d7dda8-5548-45e2-9b8d-dc644c0da0c5"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("bc89fd25-9af3-46fd-a1da-51d9b929218e"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("cd67cc06-a8c0-4c71-956e-53234dd9f37e"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("d86b8da3-21ad-460f-b511-1434b7e334ca"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("d9a8ba77-5d0e-4ae7-8b7b-44bd15a12feb"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("e0484bba-57b1-4eae-a826-6d5f676bc37d"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("e312e47c-d922-4ce9-87f2-a133c67ca046"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("e4d71b9d-fc15-475f-a990-dc53948e304d"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("e5720887-3f4e-4f49-828a-c0945d4b03a0"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("ec01f0db-b0cc-4295-b442-b797c3dc47df"));

            migrationBuilder.DeleteData(
                table: "RecetaInstruccion",
                keyColumn: "IdRecetaInstruccion",
                keyValue: new Guid("ef558fe6-99d5-41c3-b59c-d3795faba4ec"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("01b72770-ae8c-4388-9a18-cfd640e1d8c8"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("07e45ecc-4ed6-4372-bf7f-44f00ccca281"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("0f05cab9-29e6-4925-8e81-1260aa818163"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("1ba2a2b1-d3b4-44e3-844d-823eae6c8411"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("2f270869-7d88-4607-b394-db1f84c55322"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("35d116a9-83bd-49ae-a238-efb9070ca882"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("3ca2ff52-e9c6-4c31-bc4e-9b2cd28049ef"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("3dcd17d6-5ce4-4c9d-8c1f-f61a96a45954"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("55f73b90-e5c0-4153-9f4c-b5b688544da3"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("582b7a4d-541b-4021-9b7b-8dbdbf73342e"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("586963c6-d514-4789-8e6a-0055b7fed7cd"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("5c795374-da7d-4a04-ad2d-65a2c9aa66b9"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("7cc521ec-495e-4a08-9e46-2f226ddc4979"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("7e5b6430-1dff-4a4f-8c0d-60f37d87f1e7"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("84c48d2c-842d-4b0d-8c9b-3264499f0f0f"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("8b8b18b3-3783-415b-a6f8-09d53a8d4dfc"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("9088fd3a-e9d2-4583-a02a-f57c075cfe9c"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("93cabbc2-39a2-491e-a10d-7a1ca5fbf844"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("9748fd84-f80f-4e23-9aa4-74ca5a508be3"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("975049c9-74e8-42d1-a94f-5faf49b8590f"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("9d77a61e-4404-4f08-ae91-6bbdc1ab4d46"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("a2049b76-cd7f-4bf6-a44f-90117fc7d7da"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("a2c4c8b3-3209-4a28-aa2c-520101a95ee2"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("a934eaab-d760-4151-9f10-7041151768e7"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("ae4502e0-c112-43f8-abd0-eaa0e5e2e707"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("b0810fd3-fbbc-4e09-a842-f166d0e02003"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("bb206655-96ff-4933-a915-32bfc788a345"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("c0865709-e77d-427a-bb00-f10d83de6a6f"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("c5a5a200-b9aa-4ef8-b631-e959c325b5cb"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("c957043d-fdd7-41e2-8943-d847f2b56d60"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("d0061839-d9ad-46ba-afea-d0616dbca20f"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("ddb6572c-f24c-48cd-985e-d81442db791f"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("e6b8015b-afde-42c1-b9f8-85287f5cfe7c"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("e833429e-daee-4a9a-8625-cd0fef7d495d"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("e991e259-b090-4db7-bf72-c1782d9c32ee"));

            migrationBuilder.DeleteData(
                table: "PlanAlimentario",
                keyColumn: "IdPlanAlimentario",
                keyValue: new Guid("b1c8f0d2-3c4e-4f5a-9b6c-7d8e9f0a1b2c"));

            migrationBuilder.DropColumn(
                name: "IdContrato",
                table: "OrdenTrabajoCliente");

            migrationBuilder.DropColumn(
                name: "IdContrato",
                table: "Comida");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdOrdenTrabajo",
                table: "Comida",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "IdIngrediente", "CostoCompra", "CostoVenta", "Medicion", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { new Guid("06039340-c688-4198-be53-9b121b8b6095"), 5.0m, 8.0m, "kg", "Brócoli", "Fruta" },
                    { new Guid("0745f464-037e-480b-be23-03e496455b07"), 5.0m, 8.0m, "kg", "Calabaza", "Fruta" },
                    { new Guid("0e2c4760-659c-461b-b5a4-625f977006bb"), 5.0m, 8.0m, "kg", "Zanahoria", "Fruta" },
                    { new Guid("12aa9ee3-bd3c-484c-a884-3e3c15f41ead"), 10.0m, 15.0m, "kg", "Fideos", "Verdura" },
                    { new Guid("19463210-1541-4657-b434-40cbbe632ad0"), 5.0m, 8.0m, "kg", "Langostinos", "Fruta" },
                    { new Guid("2c769505-6d43-4c97-b41f-932ad482e392"), 5.0m, 8.0m, "kg", "Nueces", "Fruta" },
                    { new Guid("2dac2664-b05a-4d3d-a1fb-6484cf974040"), 5.0m, 8.0m, "kg", "Pan integral", "Fruta" },
                    { new Guid("3118439c-0fed-48f2-8360-7aa88c54c5fc"), 5.0m, 8.0m, "kg", "Pechuga de pollo", "Fruta" },
                    { new Guid("32f0b892-9b46-422e-b150-0371fcd53c3a"), 5.0m, 8.0m, "kg", "Hongos", "Verdura" },
                    { new Guid("3ed4a2b6-0e34-42f8-a09a-6ea9c7cc4cd7"), 5.0m, 8.0m, "kg", "Queso parmesano", "Fruta" },
                    { new Guid("44b773af-e296-4e3c-b14d-e2666a9ec9d0"), 5.0m, 8.0m, "kg", "Zanahoria", "Verdura" },
                    { new Guid("4dabd6cb-1f9b-472d-af4d-b4d33a8f5b05"), 5.0m, 8.0m, "litro", "Ajo", "Aceite" },
                    { new Guid("4db4c7f2-d408-4cd0-9158-1274da111e09"), 5.0m, 8.0m, "kg", "Puerro", "Fruta" },
                    { new Guid("56b8e3f1-1d7f-4def-9701-5c1897d615bf"), 5.0m, 8.0m, "kg", "Apio", "Fruta" },
                    { new Guid("57926f10-5803-45f6-91f0-17d0da6da8d9"), 5.0m, 8.0m, "kg", "Cebolla", "Fruta" },
                    { new Guid("5c6f43b5-4cea-44a8-bd2f-a9b10d2d8767"), 5.0m, 8.0m, "kg", "Huevos", "Fruta" },
                    { new Guid("67187905-2b25-4506-a130-80a27c14657a"), 5.0m, 8.0m, "kg", "Jengibre fresco", "Fruta" },
                    { new Guid("6a5749df-d4dc-41c0-b6ab-8695818fc9e6"), 10.0m, 15.0m, "kg", "Brócoli", "Verdura" },
                    { new Guid("70b99e59-1771-4e65-8089-ffac97b1d6f3"), 5.0m, 8.0m, "kg", "Lentejas", "Fruta" },
                    { new Guid("77fe8568-533f-44dd-b1bf-945e688ecd3a"), 5.0m, 8.0m, "kg", "Aceite de oliva", "Fruta" },
                    { new Guid("7e976679-6260-4ddc-bdaf-1893f97b49a2"), 5.0m, 8.0m, "kg", "Sal", "Fruta" },
                    { new Guid("8086a17c-8982-46e2-ac9b-1daaeb851511"), 5.0m, 8.0m, "kg", "Calabacín", "Fruta" },
                    { new Guid("86c608c6-a760-45c1-a0fd-3f5be3e80e0f"), 5.0m, 8.0m, "kg", "Zanahoria", "Fruta" },
                    { new Guid("98984a30-ca54-409b-8414-5d63f874990b"), 5.0m, 8.0m, "kg", "Cebolla", "Fruta" },
                    { new Guid("9e2a9322-8141-4217-9676-f0854e6be3bb"), 5.0m, 8.0m, "lt", "Caldo de pollo bajo en sodio", "Fruta" },
                    { new Guid("ab285967-94c6-48a2-b66d-42971e3054ae"), 5.0m, 8.0m, "kg", "Almendras", "Fruta" },
                    { new Guid("b0a2dd75-e553-4449-8361-4fdde9dd5cd9"), 5.0m, 8.0m, "kg", "Cúrcuma", "Fruta" },
                    { new Guid("d8b1ac8c-ff87-4f98-bb99-01a74e468068"), 5.0m, 8.0m, "litro", "Aceite de oliva", "Aceite" },
                    { new Guid("defe0a39-59e9-4700-85b1-fbcfd707ecd8"), 5.0m, 8.0m, "kg", "Palta", "Fruta" },
                    { new Guid("df14fcb6-b47c-4a1e-b168-fea14acd34e9"), 5.0m, 8.0m, "kg", "Hierbas frescas", "Fruta" },
                    { new Guid("ec8e74f0-0374-458d-bddf-aca570199fdf"), 5.0m, 8.0m, "kg", "Limón", "Fruta" },
                    { new Guid("eeb37d25-bed5-47df-895b-d1d71991ba41"), 5.0m, 8.0m, "kg", "Pimiento verde", "Fruta" },
                    { new Guid("f81da1c8-3a09-435a-98bd-a57f01c4bd88"), 5.0m, 8.0m, "kg", "Huevo", "Fruta" },
                    { new Guid("fa650ba6-9eaa-4f17-96a4-4a389587e958"), 5.0m, 8.0m, "kg", "Tomillo", "Fruta" },
                    { new Guid("fec95a30-bf71-431e-867e-8e772ba4111e"), 5.0m, 8.0m, "kg", "Cuscús", "Fruta" }
                });

            migrationBuilder.InsertData(
                table: "RecetaInstruccion",
                columns: new[] { "IdRecetaInstruccion", "IdReceta", "Instruccion" },
                values: new object[,]
                {
                    { new Guid("0413cadb-11f8-40ee-82bd-3519d20233a7"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "3. Agrega los hongos y saltéalos por 10 minutos." },
                    { new Guid("0476c087-ae00-4995-bef4-b1bb5622ae35"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "1. Pela y corta las verduras en trozos pequeños." },
                    { new Guid("0d6464de-cb60-4ab2-b996-12bb3efac8cd"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "1. Cocina el cuscús según las instrucciones del paquete." },
                    { new Guid("0ed37ae3-7200-4f57-a9a3-926af7723a30"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "2. Saltea la cebolla y el puerro en una olla con aceite." },
                    { new Guid("0eeaa4e4-f78a-40ac-b4bd-f9675e859ca3"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "4. Incorpora el brócoli y el jengibre rallado. Cocina por 10 minutos." },
                    { new Guid("1f820b52-f93c-4494-a466-9dbe9b9f4173"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "2. Pica las almendras y agrégalas." },
                    { new Guid("287aa52a-1cd7-46c2-ab20-b2881904623b"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "1. Cocina la calabaza y mézclala con las lentejas." },
                    { new Guid("30ff4ce5-06b5-45e1-84c6-8a941588fcd5"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "4. Añade los langostinos y cocina hasta que estén dorados." },
                    { new Guid("37e39156-d452-406f-a968-9329a3d2fbfe"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "3. Agrega el resto de las verduras y cocina por 5 minutos." },
                    { new Guid("47522d10-132b-4e1e-8e62-e0504f3383f5"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "4. Cocina hasta que el pollo esté bien cocido." },
                    { new Guid("490efb22-ea42-4357-a52e-32144bcffeec"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "4. Sirve con hummus por encima." },
                    { new Guid("59939db8-0718-4049-add9-fd34fb96e0c1"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "2. Agrega la cebolla y zanahoria picadas y sofríe por unos minutos." },
                    { new Guid("59a7382e-7091-4ff1-9e69-38daaee7f6d6"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "5. Incorpora los huevos batidos y revuelve hasta que cuajen." },
                    { new Guid("83af7ebe-12e0-447e-a4c6-65ab24f18c0c"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "3. Agrega el pimiento, calabacín y pollo troceado." },
                    { new Guid("b857ef2b-5cd6-495d-8b89-a027136d5daf"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "5. Cocina a fuego lento por 15 minutos y cuela el caldo." },
                    { new Guid("bcc129e2-d309-4828-82c7-edb1b9613c39"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "2. Dora el ajo en una sartén con aceite." },
                    { new Guid("c1bc7018-0d4a-4901-b447-ba2e42fa9e64"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "3. Añade el caldo de pollo y deja hervir." },
                    { new Guid("c3d6adb5-71c3-4d26-a516-fb2d6147918c"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "3. Prepara una vinagreta con aceite de oliva y limón." },
                    { new Guid("ceb44330-9b85-4864-9704-3cbcc80d2324"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "2. Machaca la palta y úntala sobre el pan." },
                    { new Guid("d36861c3-4df9-485e-b896-0ed3f12ee29f"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "4. Añade agua y hierbas aromáticas." },
                    { new Guid("d38600da-f740-4e0a-949f-a5bab086840f"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "4. Espolvorea queso parmesano y hierbas frescas." },
                    { new Guid("ddd33118-7eb5-42d0-8bd9-571aa00c7983"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "3. Aliña con aceite de oliva y sal." },
                    { new Guid("deb42c99-787c-4051-bf2c-7428e56940f3"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "1. Cocina los fideos en agua hirviendo." },
                    { new Guid("e20d1170-072b-4697-8626-b108849d4001"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "1. Cocina el pollo en una cacerola con un poco de aceite hasta dorarlo." },
                    { new Guid("e2a8025e-8ded-41e6-ba08-8d5152d95808"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "3. Cocina el huevo escalfado y colócalo encima." },
                    { new Guid("e3b91da5-e0f6-4fd6-905c-b17b76c817c2"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "2. Ralla la zanahoria y mézclala con el brócoli." },
                    { new Guid("e54802df-bec4-4fd7-9570-d7c79c19b30f"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "5. Mezcla con el cuscús y espolvorea cúrcuma." },
                    { new Guid("eb4ff17c-eae8-4569-b535-aeff70903141"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "1. Tuesta el pan integral." },
                    { new Guid("f27a3e6e-a4b5-4a5a-88a2-67ae0f2a346e"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "2. Saltea la cebolla picada hasta que esté dorada." },
                    { new Guid("f4c716df-d287-43c1-a3e2-ffb7dd1bc698"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "4. Pica las nueces y agrégalas a la ensalada." },
                    { new Guid("fd0b4eef-c47b-429d-92c6-2a84027ffd92"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "1. Cocina el brócoli en agua con sal durante 5 minutos." }
                });

            migrationBuilder.InsertData(
                table: "RecetaIngrediente",
                columns: new[] { "IdRecetaIngrediente", "Cantidad", "Detalle", "IdIngrediente", "IdReceta" },
                values: new object[,]
                {
                    { new Guid("166a1ed5-daef-4475-9c7f-ec25dbb2b33f"), 1.0, "", new Guid("3118439c-0fed-48f2-8360-7aa88c54c5fc"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("3028a30f-d3b4-47f4-af18-0f89324fffbe"), 2.0, "", new Guid("2c769505-6d43-4c97-b41f-932ad482e392"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("30e45c75-bf1f-4341-b4ae-03b8cee6e789"), 1.0, "", new Guid("5c6f43b5-4cea-44a8-bd2f-a9b10d2d8767"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("3f5d575b-15fe-415b-a697-60e234f7f52c"), 1.0, "", new Guid("67187905-2b25-4506-a130-80a27c14657a"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("3fffac45-8a06-4556-bda9-8fca0eccf11b"), 2.0, "", new Guid("ec8e74f0-0374-458d-bddf-aca570199fdf"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("40c0485a-9790-4c68-8a31-f2041485c895"), 1.0, "", new Guid("defe0a39-59e9-4700-85b1-fbcfd707ecd8"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("486738dd-3b9c-48bd-ba60-aeeec60d7c8f"), 0.5, "", new Guid("ab285967-94c6-48a2-b66d-42971e3054ae"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("59cdbb6f-68e7-494b-bc5d-41b860e0e60c"), 1.0, "", new Guid("77fe8568-533f-44dd-b1bf-945e688ecd3a"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("5ab78f81-87d2-498e-94f1-231aa8dfa5bf"), 1.0, "", new Guid("6a5749df-d4dc-41c0-b6ab-8695818fc9e6"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("5b7d3848-9e4a-4063-8861-41d234f2381d"), 2.0, "", new Guid("56b8e3f1-1d7f-4def-9701-5c1897d615bf"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("6160026e-9a9f-482b-8afb-7ac04dd55c15"), 1.0, "", new Guid("7e976679-6260-4ddc-bdaf-1893f97b49a2"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("65548f1b-feba-40e0-8a91-a363319c9041"), 1.0, "", new Guid("57926f10-5803-45f6-91f0-17d0da6da8d9"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("6e392090-fd95-4405-ac36-409ec4759a42"), 1.0, "", new Guid("0745f464-037e-480b-be23-03e496455b07"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") },
                    { new Guid("716b380b-1bee-4629-b09e-9f1ba06a7f97"), 2.0, "", new Guid("19463210-1541-4657-b434-40cbbe632ad0"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("72db7bc6-a6d6-4f11-864c-8f382a2c266d"), 0.5, "", new Guid("eeb37d25-bed5-47df-895b-d1d71991ba41"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("8195bdbc-00a0-4917-8ce5-8dc0986106c2"), 1.0, "", new Guid("12aa9ee3-bd3c-484c-a884-3e3c15f41ead"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("84072b97-77c9-4ccb-9b9b-d29ede40db54"), 1.0, "", new Guid("fa650ba6-9eaa-4f17-96a4-4a389587e958"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("93127af8-53be-4935-a33a-44c8bf6d6fea"), 2.0, "", new Guid("32f0b892-9b46-422e-b150-0371fcd53c3a"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("9742cbf8-4db4-4605-9c6f-e9fada719add"), 0.5, "", new Guid("4db4c7f2-d408-4cd0-9158-1274da111e09"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("9cb5baaa-1c99-4101-81f9-3ced1057b715"), 1.0, "", new Guid("b0a2dd75-e553-4449-8361-4fdde9dd5cd9"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("9e874ca6-76dd-41d1-bbf3-809585eb29ae"), 0.5, "", new Guid("f81da1c8-3a09-435a-98bd-a57f01c4bd88"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("a8fffd2d-4255-47ef-a0e8-8922d5178b32"), 1.0, "", new Guid("3ed4a2b6-0e34-42f8-a09a-6ea9c7cc4cd7"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("ac457561-0556-4c8b-a886-9b6e095cfcc1"), 1.0, "", new Guid("0e2c4760-659c-461b-b5a4-625f977006bb"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("ad97edc6-71fd-44d9-ae11-b9cca918308b"), 1.0, "", new Guid("9e2a9322-8141-4217-9676-f0854e6be3bb"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("b4030821-5d3d-48b9-b19c-4d0b741717a8"), 1.0, "", new Guid("86c608c6-a760-45c1-a0fd-3f5be3e80e0f"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7") },
                    { new Guid("b913dea9-e201-42d5-b800-7d8ee5269245"), 1.0, "", new Guid("d8b1ac8c-ff87-4f98-bb99-01a74e468068"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("baff6777-24ab-49ea-9433-0514ffd94f6f"), 1.0, "", new Guid("df14fcb6-b47c-4a1e-b168-fea14acd34e9"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("bfc9ca35-e128-4e40-abbe-b1877bd1b3d4"), 1.0, "", new Guid("4dabd6cb-1f9b-472d-af4d-b4d33a8f5b05"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227") },
                    { new Guid("c31db85c-e0bb-4497-92d1-06be898bfcb7"), 0.5, "", new Guid("06039340-c688-4198-be53-9b121b8b6095"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("c8fff2ed-f9bd-4784-b37d-98001112329a"), 1.0, "", new Guid("8086a17c-8982-46e2-ac9b-1daaeb851511"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("db320652-02b5-4b56-b27f-1b1ce746e6f3"), 2.0, "", new Guid("fec95a30-bf71-431e-867e-8e772ba4111e"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2") },
                    { new Guid("dd0ec80c-ccd2-412e-bcd9-d91c3b8253e2"), 2.0, "", new Guid("2dac2664-b05a-4d3d-a1fb-6484cf974040"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df") },
                    { new Guid("e2b2ece3-d813-4414-a72f-77e35f54c1dc"), 2.0, "", new Guid("98984a30-ca54-409b-8414-5d63f874990b"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04") },
                    { new Guid("eaba08a6-c753-43f8-b9db-5d7ea87eb839"), 1.0, "", new Guid("44b773af-e296-4e3c-b14d-e2666a9ec9d0"), new Guid("38b29f41-0757-4f98-af43-84394606eb03") },
                    { new Guid("fbd088e2-e31b-4b08-b2d8-5e8f35bfa6be"), 2.0, "", new Guid("70b99e59-1771-4e65-8089-ffac97b1d6f3"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comida_OrdenTrabajo_IdOrdenTrabajo",
                table: "Comida",
                column: "IdOrdenTrabajo",
                principalTable: "OrdenTrabajo",
                principalColumn: "IdOrdenTrabajo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
