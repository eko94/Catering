using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRecetas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cliente",
                keyColumn: "IdCliente",
                keyValue: new Guid("a71010c7-979b-4217-a899-c1c3d8179f4a"));

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

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"));

            migrationBuilder.DeleteData(
                table: "Ingrediente",
                keyColumn: "IdIngrediente",
                keyValue: new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"));

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "IdCliente",
                keyValue: new Guid("9b971b55-e539-4939-9240-825a48402329"),
                column: "Nombre",
                value: "Cliente Test");

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

            migrationBuilder.UpdateData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("38b29f41-0757-4f98-af43-84394606eb03"),
                column: "Nombre",
                value: "Ensalada de brócoli, zanahoria y nueces");

            migrationBuilder.UpdateData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"),
                column: "Nombre",
                value: "Fideos con revuelto de hongos y langostinos");

            migrationBuilder.InsertData(
                table: "Receta",
                columns: new[] { "IdReceta", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "Sopa de pollo con vegetales" },
                    { new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "Cuscús con pollo, verduras y cúrcuma" },
                    { new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "Ensalada de lentejas con calabaza, hummus y almendras" },
                    { new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "Caldo de verduras rápido" },
                    { new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "Tostada con palta y huevo escalfado" }
                });

            migrationBuilder.InsertData(
                table: "RecetaInstruccion",
                columns: new[] { "IdRecetaInstruccion", "IdReceta", "Instruccion" },
                values: new object[,]
                {
                    { new Guid("0413cadb-11f8-40ee-82bd-3519d20233a7"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "3. Agrega los hongos y saltéalos por 10 minutos." },
                    { new Guid("30ff4ce5-06b5-45e1-84c6-8a941588fcd5"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "4. Añade los langostinos y cocina hasta que estén dorados." },
                    { new Guid("59a7382e-7091-4ff1-9e69-38daaee7f6d6"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "5. Incorpora los huevos batidos y revuelve hasta que cuajen." },
                    { new Guid("bcc129e2-d309-4828-82c7-edb1b9613c39"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "2. Dora el ajo en una sartén con aceite." },
                    { new Guid("c3d6adb5-71c3-4d26-a516-fb2d6147918c"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "3. Prepara una vinagreta con aceite de oliva y limón." },
                    { new Guid("deb42c99-787c-4051-bf2c-7428e56940f3"), new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"), "1. Cocina los fideos en agua hirviendo." },
                    { new Guid("e3b91da5-e0f6-4fd6-905c-b17b76c817c2"), new Guid("38b29f41-0757-4f98-af43-84394606eb03"), "2. Ralla la zanahoria y mézclala con el brócoli." },
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

            migrationBuilder.InsertData(
                table: "RecetaInstruccion",
                columns: new[] { "IdRecetaInstruccion", "IdReceta", "Instruccion" },
                values: new object[,]
                {
                    { new Guid("0476c087-ae00-4995-bef4-b1bb5622ae35"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "1. Pela y corta las verduras en trozos pequeños." },
                    { new Guid("0d6464de-cb60-4ab2-b996-12bb3efac8cd"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "1. Cocina el cuscús según las instrucciones del paquete." },
                    { new Guid("0ed37ae3-7200-4f57-a9a3-926af7723a30"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "2. Saltea la cebolla y el puerro en una olla con aceite." },
                    { new Guid("0eeaa4e4-f78a-40ac-b4bd-f9675e859ca3"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "4. Incorpora el brócoli y el jengibre rallado. Cocina por 10 minutos." },
                    { new Guid("1f820b52-f93c-4494-a466-9dbe9b9f4173"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "2. Pica las almendras y agrégalas." },
                    { new Guid("287aa52a-1cd7-46c2-ab20-b2881904623b"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "1. Cocina la calabaza y mézclala con las lentejas." },
                    { new Guid("37e39156-d452-406f-a968-9329a3d2fbfe"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "3. Agrega el resto de las verduras y cocina por 5 minutos." },
                    { new Guid("47522d10-132b-4e1e-8e62-e0504f3383f5"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "4. Cocina hasta que el pollo esté bien cocido." },
                    { new Guid("490efb22-ea42-4357-a52e-32144bcffeec"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "4. Sirve con hummus por encima." },
                    { new Guid("59939db8-0718-4049-add9-fd34fb96e0c1"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "2. Agrega la cebolla y zanahoria picadas y sofríe por unos minutos." },
                    { new Guid("83af7ebe-12e0-447e-a4c6-65ab24f18c0c"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "3. Agrega el pimiento, calabacín y pollo troceado." },
                    { new Guid("b857ef2b-5cd6-495d-8b89-a027136d5daf"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "5. Cocina a fuego lento por 15 minutos y cuela el caldo." },
                    { new Guid("c1bc7018-0d4a-4901-b447-ba2e42fa9e64"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "3. Añade el caldo de pollo y deja hervir." },
                    { new Guid("ceb44330-9b85-4864-9704-3cbcc80d2324"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "2. Machaca la palta y úntala sobre el pan." },
                    { new Guid("d36861c3-4df9-485e-b896-0ed3f12ee29f"), new Guid("acf9388f-1ae9-4888-871a-720651408cf7"), "4. Añade agua y hierbas aromáticas." },
                    { new Guid("d38600da-f740-4e0a-949f-a5bab086840f"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "4. Espolvorea queso parmesano y hierbas frescas." },
                    { new Guid("ddd33118-7eb5-42d0-8bd9-571aa00c7983"), new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"), "3. Aliña con aceite de oliva y sal." },
                    { new Guid("e20d1170-072b-4697-8626-b108849d4001"), new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"), "1. Cocina el pollo en una cacerola con un poco de aceite hasta dorarlo." },
                    { new Guid("e2a8025e-8ded-41e6-ba08-8d5152d95808"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "3. Cocina el huevo escalfado y colócalo encima." },
                    { new Guid("e54802df-bec4-4fd7-9570-d7c79c19b30f"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "5. Mezcla con el cuscús y espolvorea cúrcuma." },
                    { new Guid("eb4ff17c-eae8-4569-b535-aeff70903141"), new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"), "1. Tuesta el pan integral." },
                    { new Guid("f27a3e6e-a4b5-4a5a-88a2-67ae0f2a346e"), new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"), "2. Saltea la cebolla picada hasta que esté dorada." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("0c18e665-5a64-4ba3-8903-999bb5c50d04"));

            migrationBuilder.DeleteData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("3aa49abb-9458-4097-8bc0-70118fe7e9f2"));

            migrationBuilder.DeleteData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("7f4423a6-f047-4759-b6be-b9260f9d7e15"));

            migrationBuilder.DeleteData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("acf9388f-1ae9-4888-871a-720651408cf7"));

            migrationBuilder.DeleteData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("faac0c33-64f8-4c92-840b-5c0d708719df"));

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "IdCliente",
                keyValue: new Guid("9b971b55-e539-4939-9240-825a48402329"),
                column: "Nombre",
                value: "Cliente 1");

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "IdCliente", "Nombre" },
                values: new object[] { new Guid("a71010c7-979b-4217-a899-c1c3d8179f4a"), "Cliente 2" });

            migrationBuilder.InsertData(
                table: "Ingrediente",
                columns: new[] { "IdIngrediente", "CostoCompra", "CostoVenta", "Medicion", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { new Guid("74998d4d-4271-46df-a900-e3c8bcb9020a"), 10.0m, 15.0m, "kg", "Ingrediente 1", "Tipo 1" },
                    { new Guid("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), 5.0m, 8.0m, "litro", "Ingrediente 2", "Tipo 2" }
                });

            migrationBuilder.UpdateData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("38b29f41-0757-4f98-af43-84394606eb03"),
                column: "Nombre",
                value: "Receta 1");

            migrationBuilder.UpdateData(
                table: "Receta",
                keyColumn: "IdReceta",
                keyValue: new Guid("3d906ea7-e3a3-480d-b2ce-5b4f7586f227"),
                column: "Nombre",
                value: "Receta 2");

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
        }
    }
}
