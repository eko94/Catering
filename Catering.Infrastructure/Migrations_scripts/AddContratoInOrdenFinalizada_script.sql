USE [Catering]

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

IF (SELECT MigrationId FROM [dbo].[__EFMigrationsHistory] WHERE MigrationId = '20250628230917_AddContratoInOrdenFinalizada') IS NOT NULL
	RETURN;

BEGIN TRANSACTION;
ALTER TABLE [Comida] DROP CONSTRAINT [FK_Comida_OrdenTrabajo_IdOrdenTrabajo];

DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '166a1ed5-daef-4475-9c7f-ec25dbb2b33f';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '3028a30f-d3b4-47f4-af18-0f89324fffbe';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '30e45c75-bf1f-4341-b4ae-03b8cee6e789';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '3f5d575b-15fe-415b-a697-60e234f7f52c';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '3fffac45-8a06-4556-bda9-8fca0eccf11b';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '40c0485a-9790-4c68-8a31-f2041485c895';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '486738dd-3b9c-48bd-ba60-aeeec60d7c8f';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '59cdbb6f-68e7-494b-bc5d-41b860e0e60c';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '5ab78f81-87d2-498e-94f1-231aa8dfa5bf';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '5b7d3848-9e4a-4063-8861-41d234f2381d';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '6160026e-9a9f-482b-8afb-7ac04dd55c15';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '65548f1b-feba-40e0-8a91-a363319c9041';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '6e392090-fd95-4405-ac36-409ec4759a42';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '716b380b-1bee-4629-b09e-9f1ba06a7f97';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '72db7bc6-a6d6-4f11-864c-8f382a2c266d';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '8195bdbc-00a0-4917-8ce5-8dc0986106c2';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '84072b97-77c9-4ccb-9b9b-d29ede40db54';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '93127af8-53be-4935-a33a-44c8bf6d6fea';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '9742cbf8-4db4-4605-9c6f-e9fada719add';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '9cb5baaa-1c99-4101-81f9-3ced1057b715';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '9e874ca6-76dd-41d1-bbf3-809585eb29ae';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'a8fffd2d-4255-47ef-a0e8-8922d5178b32';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'ac457561-0556-4c8b-a886-9b6e095cfcc1';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'ad97edc6-71fd-44d9-ae11-b9cca918308b';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'b4030821-5d3d-48b9-b19c-4d0b741717a8';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'b913dea9-e201-42d5-b800-7d8ee5269245';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'baff6777-24ab-49ea-9433-0514ffd94f6f';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'bfc9ca35-e128-4e40-abbe-b1877bd1b3d4';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'c31db85c-e0bb-4497-92d1-06be898bfcb7';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'c8fff2ed-f9bd-4784-b37d-98001112329a';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'db320652-02b5-4b56-b27f-1b1ce746e6f3';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'dd0ec80c-ccd2-412e-bcd9-d91c3b8253e2';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'e2b2ece3-d813-4414-a72f-77e35f54c1dc';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'eaba08a6-c753-43f8-b9db-5d7ea87eb839';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'fbd088e2-e31b-4b08-b2d8-5e8f35bfa6be';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '0413cadb-11f8-40ee-82bd-3519d20233a7';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '0476c087-ae00-4995-bef4-b1bb5622ae35';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '0d6464de-cb60-4ab2-b996-12bb3efac8cd';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '0ed37ae3-7200-4f57-a9a3-926af7723a30';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '0eeaa4e4-f78a-40ac-b4bd-f9675e859ca3';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '1f820b52-f93c-4494-a466-9dbe9b9f4173';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '287aa52a-1cd7-46c2-ab20-b2881904623b';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '30ff4ce5-06b5-45e1-84c6-8a941588fcd5';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '37e39156-d452-406f-a968-9329a3d2fbfe';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '47522d10-132b-4e1e-8e62-e0504f3383f5';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '490efb22-ea42-4357-a52e-32144bcffeec';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '59939db8-0718-4049-add9-fd34fb96e0c1';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '59a7382e-7091-4ff1-9e69-38daaee7f6d6';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '83af7ebe-12e0-447e-a4c6-65ab24f18c0c';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'b857ef2b-5cd6-495d-8b89-a027136d5daf';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'bcc129e2-d309-4828-82c7-edb1b9613c39';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'c1bc7018-0d4a-4901-b447-ba2e42fa9e64';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'c3d6adb5-71c3-4d26-a516-fb2d6147918c';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'ceb44330-9b85-4864-9704-3cbcc80d2324';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'd36861c3-4df9-485e-b896-0ed3f12ee29f';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'd38600da-f740-4e0a-949f-a5bab086840f';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'ddd33118-7eb5-42d0-8bd9-571aa00c7983';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'deb42c99-787c-4051-bf2c-7428e56940f3';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'e20d1170-072b-4697-8626-b108849d4001';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'e2a8025e-8ded-41e6-ba08-8d5152d95808';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'e3b91da5-e0f6-4fd6-905c-b17b76c817c2';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'e54802df-bec4-4fd7-9570-d7c79c19b30f';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'eb4ff17c-eae8-4569-b535-aeff70903141';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'f27a3e6e-a4b5-4a5a-88a2-67ae0f2a346e';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'f4c716df-d287-43c1-a3e2-ffb7dd1bc698';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'fd0b4eef-c47b-429d-92c6-2a84027ffd92';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '06039340-c688-4198-be53-9b121b8b6095';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '0745f464-037e-480b-be23-03e496455b07';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '0e2c4760-659c-461b-b5a4-625f977006bb';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '12aa9ee3-bd3c-484c-a884-3e3c15f41ead';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '19463210-1541-4657-b434-40cbbe632ad0';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '2c769505-6d43-4c97-b41f-932ad482e392';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '2dac2664-b05a-4d3d-a1fb-6484cf974040';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '3118439c-0fed-48f2-8360-7aa88c54c5fc';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '32f0b892-9b46-422e-b150-0371fcd53c3a';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '3ed4a2b6-0e34-42f8-a09a-6ea9c7cc4cd7';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '44b773af-e296-4e3c-b14d-e2666a9ec9d0';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '4dabd6cb-1f9b-472d-af4d-b4d33a8f5b05';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '4db4c7f2-d408-4cd0-9158-1274da111e09';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '56b8e3f1-1d7f-4def-9701-5c1897d615bf';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '57926f10-5803-45f6-91f0-17d0da6da8d9';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '5c6f43b5-4cea-44a8-bd2f-a9b10d2d8767';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '67187905-2b25-4506-a130-80a27c14657a';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '6a5749df-d4dc-41c0-b6ab-8695818fc9e6';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '70b99e59-1771-4e65-8089-ffac97b1d6f3';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '77fe8568-533f-44dd-b1bf-945e688ecd3a';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '7e976679-6260-4ddc-bdaf-1893f97b49a2';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '8086a17c-8982-46e2-ac9b-1daaeb851511';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '86c608c6-a760-45c1-a0fd-3f5be3e80e0f';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '98984a30-ca54-409b-8414-5d63f874990b';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '9e2a9322-8141-4217-9676-f0854e6be3bb';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'ab285967-94c6-48a2-b66d-42971e3054ae';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'b0a2dd75-e553-4449-8361-4fdde9dd5cd9';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'd8b1ac8c-ff87-4f98-bb99-01a74e468068';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'defe0a39-59e9-4700-85b1-fbcfd707ecd8';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'df14fcb6-b47c-4a1e-b168-fea14acd34e9';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'ec8e74f0-0374-458d-bddf-aca570199fdf';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'eeb37d25-bed5-47df-895b-d1d71991ba41';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'f81da1c8-3a09-435a-98bd-a57f01c4bd88';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'fa650ba6-9eaa-4f17-96a4-4a389587e958';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'fec95a30-bf71-431e-867e-8e772ba4111e';
SELECT @@ROWCOUNT;


ALTER TABLE [OrdenTrabajoCliente] ADD [IdContrato] uniqueidentifier NOT NULL;

DECLARE @var sysname;
SELECT @var = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Comida]') AND [c].[name] = N'IdOrdenTrabajo');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [Comida] DROP CONSTRAINT [' + @var + '];');
ALTER TABLE [Comida] ALTER COLUMN [IdOrdenTrabajo] uniqueidentifier NULL;

ALTER TABLE [Comida] ADD [IdContrato] uniqueidentifier NULL;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdIngrediente', N'CostoCompra', N'CostoVenta', N'Medicion', N'Nombre', N'Tipo') AND [object_id] = OBJECT_ID(N'[Ingrediente]'))
    SET IDENTITY_INSERT [Ingrediente] ON;
INSERT INTO [Ingrediente] ([IdIngrediente], [CostoCompra], [CostoVenta], [Medicion], [Nombre], [Tipo])
VALUES ('01b72770-ae8c-4388-9a18-cfd640e1d8c8', 5.0, 8.0, N'kg', N'Queso parmesano', N'Fruta'),
('07e45ecc-4ed6-4372-bf7f-44f00ccca281', 5.0, 8.0, N'kg', N'Huevo', N'Fruta'),
('0f05cab9-29e6-4925-8e81-1260aa818163', 10.0, 15.0, N'kg', N'Brócoli', N'Verdura'),
('1ba2a2b1-d3b4-44e3-844d-823eae6c8411', 5.0, 8.0, N'kg', N'Tomillo', N'Fruta'),
('2f270869-7d88-4607-b394-db1f84c55322', 5.0, 8.0, N'lt', N'Caldo de pollo bajo en sodio', N'Fruta'),
('35d116a9-83bd-49ae-a238-efb9070ca882', 5.0, 8.0, N'litro', N'Aceite de oliva', N'Aceite'),
('3ca2ff52-e9c6-4c31-bc4e-9b2cd28049ef', 5.0, 8.0, N'kg', N'Calabaza', N'Fruta'),
('3dcd17d6-5ce4-4c9d-8c1f-f61a96a45954', 5.0, 8.0, N'kg', N'Limón', N'Fruta'),
('55f73b90-e5c0-4153-9f4c-b5b688544da3', 5.0, 8.0, N'kg', N'Huevos', N'Fruta'),
('582b7a4d-541b-4021-9b7b-8dbdbf73342e', 5.0, 8.0, N'kg', N'Zanahoria', N'Fruta'),
('586963c6-d514-4789-8e6a-0055b7fed7cd', 5.0, 8.0, N'kg', N'Puerro', N'Fruta'),
('5c795374-da7d-4a04-ad2d-65a2c9aa66b9', 5.0, 8.0, N'kg', N'Pan integral', N'Fruta'),
('7cc521ec-495e-4a08-9e46-2f226ddc4979', 5.0, 8.0, N'kg', N'Langostinos', N'Fruta'),
('7e5b6430-1dff-4a4f-8c0d-60f37d87f1e7', 5.0, 8.0, N'kg', N'Pimiento verde', N'Fruta'),
('84c48d2c-842d-4b0d-8c9b-3264499f0f0f', 5.0, 8.0, N'kg', N'Sal', N'Fruta'),
('8b8b18b3-3783-415b-a6f8-09d53a8d4dfc', 5.0, 8.0, N'kg', N'Jengibre fresco', N'Fruta'),
('9088fd3a-e9d2-4583-a02a-f57c075cfe9c', 5.0, 8.0, N'kg', N'Pechuga de pollo', N'Fruta'),
('93cabbc2-39a2-491e-a10d-7a1ca5fbf844', 5.0, 8.0, N'kg', N'Zanahoria', N'Verdura'),
('9748fd84-f80f-4e23-9aa4-74ca5a508be3', 5.0, 8.0, N'kg', N'Palta', N'Fruta'),
('975049c9-74e8-42d1-a94f-5faf49b8590f', 5.0, 8.0, N'kg', N'Brócoli', N'Fruta'),
('9d77a61e-4404-4f08-ae91-6bbdc1ab4d46', 5.0, 8.0, N'kg', N'Cebolla', N'Fruta'),
('a2049b76-cd7f-4bf6-a44f-90117fc7d7da', 5.0, 8.0, N'kg', N'Almendras', N'Fruta'),
('a2c4c8b3-3209-4a28-aa2c-520101a95ee2', 5.0, 8.0, N'kg', N'Zanahoria', N'Fruta'),
('a934eaab-d760-4151-9f10-7041151768e7', 5.0, 8.0, N'kg', N'Calabacín', N'Fruta'),
('ae4502e0-c112-43f8-abd0-eaa0e5e2e707', 5.0, 8.0, N'kg', N'Hierbas frescas', N'Fruta'),
('b0810fd3-fbbc-4e09-a842-f166d0e02003', 10.0, 15.0, N'kg', N'Fideos', N'Verdura'),
('bb206655-96ff-4933-a915-32bfc788a345', 5.0, 8.0, N'kg', N'Cuscús', N'Fruta'),
('c0865709-e77d-427a-bb00-f10d83de6a6f', 5.0, 8.0, N'kg', N'Nueces', N'Fruta'),
('c5a5a200-b9aa-4ef8-b631-e959c325b5cb', 5.0, 8.0, N'litro', N'Ajo', N'Aceite'),
('c957043d-fdd7-41e2-8943-d847f2b56d60', 5.0, 8.0, N'kg', N'Aceite de oliva', N'Fruta'),
('d0061839-d9ad-46ba-afea-d0616dbca20f', 5.0, 8.0, N'kg', N'Lentejas', N'Fruta'),
('ddb6572c-f24c-48cd-985e-d81442db791f', 5.0, 8.0, N'kg', N'Apio', N'Fruta'),
('e6b8015b-afde-42c1-b9f8-85287f5cfe7c', 5.0, 8.0, N'kg', N'Cúrcuma', N'Fruta'),
('e833429e-daee-4a9a-8625-cd0fef7d495d', 5.0, 8.0, N'kg', N'Cebolla', N'Fruta'),
('e991e259-b090-4db7-bf72-c1782d9c32ee', 5.0, 8.0, N'kg', N'Hongos', N'Verdura');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdIngrediente', N'CostoCompra', N'CostoVenta', N'Medicion', N'Nombre', N'Tipo') AND [object_id] = OBJECT_ID(N'[Ingrediente]'))
    SET IDENTITY_INSERT [Ingrediente] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPlanAlimentario', N'CantidadDias', N'Nombre', N'Tipo') AND [object_id] = OBJECT_ID(N'[PlanAlimentario]'))
    SET IDENTITY_INSERT [PlanAlimentario] ON;
INSERT INTO [PlanAlimentario] ([IdPlanAlimentario], [CantidadDias], [Nombre], [Tipo])
VALUES ('b1c8f0d2-3c4e-4f5a-9b6c-7d8e9f0a1b2c', 15, N'Plan Alimentario Test', N'Tipo del plan alimentario test');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPlanAlimentario', N'CantidadDias', N'Nombre', N'Tipo') AND [object_id] = OBJECT_ID(N'[PlanAlimentario]'))
    SET IDENTITY_INSERT [PlanAlimentario] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] ON;
INSERT INTO [RecetaInstruccion] ([IdRecetaInstruccion], [IdReceta], [Instruccion])
VALUES ('0494c609-c170-445e-8245-ccb41b8ca446', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'3. Agrega el pimiento, calabacín y pollo troceado.'),
('04cb1dd9-7489-46d3-a682-706eb3f1845e', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'5. Incorpora los huevos batidos y revuelve hasta que cuajen.'),
('0bbb3d4d-9ade-4751-b831-87594db71991', 'acf9388f-1ae9-4888-871a-720651408cf7', N'3. Agrega el resto de las verduras y cocina por 5 minutos.'),
('100bebed-e933-40c6-b81a-ce31f9aa5a38', '38b29f41-0757-4f98-af43-84394606eb03', N'1. Cocina el brócoli en agua con sal durante 5 minutos.'),
('1c919f00-4e8e-40b3-accc-ecf250542e85', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'4. Añade los langostinos y cocina hasta que estén dorados.'),
('276fb00e-89a2-44e9-8f80-172ac6268557', 'acf9388f-1ae9-4888-871a-720651408cf7', N'2. Saltea la cebolla y el puerro en una olla con aceite.'),
('2c9a25fc-1ef1-4ba6-b0c0-f5b5ba507e00', '38b29f41-0757-4f98-af43-84394606eb03', N'2. Ralla la zanahoria y mézclala con el brócoli.'),
('3997d976-c7db-4913-9b45-508a92eb8137', '7f4423a6-f047-4759-b6be-b9260f9d7e15', N'3. Aliña con aceite de oliva y sal.'),
('3d0377e8-fbf3-4184-a1c7-9126a06bdd13', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'3. Agrega los hongos y saltéalos por 10 minutos.'),
('430ab4ab-0cac-4a4c-8898-6d276c9060f4', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'2. Saltea la cebolla picada hasta que esté dorada.'),
('48b249bb-a41c-4475-b79b-652eaa018088', 'acf9388f-1ae9-4888-871a-720651408cf7', N'5. Cocina a fuego lento por 15 minutos y cuela el caldo.'),
('4d6f0cb5-3fc0-4fe3-b7b9-5fc104fc8855', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'1. Cocina los fideos en agua hirviendo.'),
('53161d8e-0570-4766-a3f0-f3d4335d933a', 'acf9388f-1ae9-4888-871a-720651408cf7', N'1. Pela y corta las verduras en trozos pequeños.'),
('5bc31749-9881-4d75-931e-c354d5bdb1e7', '38b29f41-0757-4f98-af43-84394606eb03', N'4. Pica las nueces y agrégalas a la ensalada.'),
('6a62ea62-2e0e-43ec-bb26-9d4cd5da0948', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'4. Cocina hasta que el pollo esté bien cocido.'),
('7232ec6e-8b08-4010-afc3-60c57dc28099', '7f4423a6-f047-4759-b6be-b9260f9d7e15', N'1. Cocina la calabaza y mézclala con las lentejas.'),
('904af092-33b4-44bf-a4f3-ee651d745e65', '0c18e665-5a64-4ba3-8903-999bb5c50d04', N'2. Agrega la cebolla y zanahoria picadas y sofríe por unos minutos.'),
('a958abfc-674a-4c0b-95c1-6e8527af6427', 'faac0c33-64f8-4c92-840b-5c0d708719df', N'3. Cocina el huevo escalfado y colócalo encima.'),
('ab9ae51a-d382-4628-a5be-90e7b297273b', 'faac0c33-64f8-4c92-840b-5c0d708719df', N'1. Tuesta el pan integral.'),
('accf184a-685e-4e69-a22f-d3aabbb0b66d', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'5. Mezcla con el cuscús y espolvorea cúrcuma.'),
('b8d7dda8-5548-45e2-9b8d-dc644c0da0c5', '7f4423a6-f047-4759-b6be-b9260f9d7e15', N'4. Sirve con hummus por encima.'),
('bc89fd25-9af3-46fd-a1da-51d9b929218e', '0c18e665-5a64-4ba3-8903-999bb5c50d04', N'4. Incorpora el brócoli y el jengibre rallado. Cocina por 10 minutos.'),
('cd67cc06-a8c0-4c71-956e-53234dd9f37e', 'faac0c33-64f8-4c92-840b-5c0d708719df', N'2. Machaca la palta y úntala sobre el pan.'),
('d86b8da3-21ad-460f-b511-1434b7e334ca', 'acf9388f-1ae9-4888-871a-720651408cf7', N'4. Añade agua y hierbas aromáticas.'),
('d9a8ba77-5d0e-4ae7-8b7b-44bd15a12feb', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'1. Cocina el cuscús según las instrucciones del paquete.'),
('e0484bba-57b1-4eae-a826-6d5f676bc37d', '38b29f41-0757-4f98-af43-84394606eb03', N'3. Prepara una vinagreta con aceite de oliva y limón.'),
('e312e47c-d922-4ce9-87f2-a133c67ca046', '0c18e665-5a64-4ba3-8903-999bb5c50d04', N'3. Añade el caldo de pollo y deja hervir.'),
('e4d71b9d-fc15-475f-a990-dc53948e304d', '0c18e665-5a64-4ba3-8903-999bb5c50d04', N'1. Cocina el pollo en una cacerola con un poco de aceite hasta dorarlo.'),
('e5720887-3f4e-4f49-828a-c0945d4b03a0', '7f4423a6-f047-4759-b6be-b9260f9d7e15', N'2. Pica las almendras y agrégalas.'),
('ec01f0db-b0cc-4295-b442-b797c3dc47df', 'faac0c33-64f8-4c92-840b-5c0d708719df', N'4. Espolvorea queso parmesano y hierbas frescas.'),
('ef558fe6-99d5-41c3-b59c-d3795faba4ec', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'2. Dora el ajo en una sartén con aceite.');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdContrato', N'DiasContratados', N'DiasRealizados', N'Estado', N'FechaInicio', N'FechaUltimoRealizado', N'IdCliente', N'IdPlanAlimentario') AND [object_id] = OBJECT_ID(N'[Contrato]'))
    SET IDENTITY_INSERT [Contrato] ON;
INSERT INTO [Contrato] ([IdContrato], [DiasContratados], [DiasRealizados], [Estado], [FechaInicio], [FechaUltimoRealizado], [IdCliente], [IdPlanAlimentario])
VALUES ('5faf7842-e7b5-4a3f-96c8-7719d01748b9', 15, 0, N'Iniciado', '2025-06-28T00:00:00.0000000-04:00', NULL, '9b971b55-e539-4939-9240-825a48402329', 'b1c8f0d2-3c4e-4f5a-9b6c-7d8e9f0a1b2c');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdContrato', N'DiasContratados', N'DiasRealizados', N'Estado', N'FechaInicio', N'FechaUltimoRealizado', N'IdCliente', N'IdPlanAlimentario') AND [object_id] = OBJECT_ID(N'[Contrato]'))
    SET IDENTITY_INSERT [Contrato] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaIngrediente', N'Cantidad', N'Detalle', N'IdIngrediente', N'IdReceta') AND [object_id] = OBJECT_ID(N'[RecetaIngrediente]'))
    SET IDENTITY_INSERT [RecetaIngrediente] ON;
INSERT INTO [RecetaIngrediente] ([IdRecetaIngrediente], [Cantidad], [Detalle], [IdIngrediente], [IdReceta])
VALUES ('024295a8-ee8d-4d68-95ad-29a6a530f804', 1.0E0, N'', '0f05cab9-29e6-4925-8e81-1260aa818163', '38b29f41-0757-4f98-af43-84394606eb03'),
('0f41312d-5374-40be-998b-c2bf1e6439ac', 1.0E0, N'', 'ae4502e0-c112-43f8-abd0-eaa0e5e2e707', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('17fbfe8a-58aa-4330-8d9c-ffd86e058380', 2.0E0, N'', '3dcd17d6-5ce4-4c9d-8c1f-f61a96a45954', '38b29f41-0757-4f98-af43-84394606eb03'),
('1a809aa1-bfd1-4c5e-bbc7-9ad0f99c9561', 2.0E0, N'', '9d77a61e-4404-4f08-ae91-6bbdc1ab4d46', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('1d440379-abff-48bf-b3fe-2be1f2bc7ea1', 1.0E0, N'', '2f270869-7d88-4607-b394-db1f84c55322', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('1e930973-4336-4866-9943-8c47a29ad462', 2.0E0, N'', 'ddb6572c-f24c-48cd-985e-d81442db791f', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('1f08902e-539d-4bf1-98df-631f194f445d', 1.0E0, N'', '3ca2ff52-e9c6-4c31-bc4e-9b2cd28049ef', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('2377e2de-6966-434c-9fbb-2206c0eafebc', 0.5E0, N'', '975049c9-74e8-42d1-a94f-5faf49b8590f', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('326e4375-ee15-45f6-b005-2304c61a81c2', 1.0E0, N'', '35d116a9-83bd-49ae-a238-efb9070ca882', '38b29f41-0757-4f98-af43-84394606eb03'),
('426c988f-5929-4819-a81e-17cf6d7c130c', 1.0E0, N'', '9748fd84-f80f-4e23-9aa4-74ca5a508be3', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('4578a298-7e95-4990-8852-3477bf92cc9c', 2.0E0, N'', '7cc521ec-495e-4a08-9e46-2f226ddc4979', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('6a91ff7c-827e-417a-9f4b-06b7d5aad185', 0.5E0, N'', 'a2049b76-cd7f-4bf6-a44f-90117fc7d7da', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('6f700eb6-4c1b-474a-9577-eb6d53720e45', 0.5E0, N'', '586963c6-d514-4789-8e6a-0055b7fed7cd', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('70b624f9-c252-4031-8b55-9cecf0b7fc01', 2.0E0, N'', 'bb206655-96ff-4933-a915-32bfc788a345', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('72e7875e-642b-4645-9541-6621d38ee57a', 2.0E0, N'', '5c795374-da7d-4a04-ad2d-65a2c9aa66b9', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('793e85e4-553c-4f28-a9d0-0afc376cb185', 2.0E0, N'', 'd0061839-d9ad-46ba-afea-d0616dbca20f', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('7dc93e3d-2538-494a-abb1-a71552bea199', 1.0E0, N'', '93cabbc2-39a2-491e-a10d-7a1ca5fbf844', '38b29f41-0757-4f98-af43-84394606eb03'),
('85965ca5-55ba-4f19-99a9-a72cb3837aa2', 0.5E0, N'', '7e5b6430-1dff-4a4f-8c0d-60f37d87f1e7', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('881b7716-ef49-4d19-b13b-faccbf8a33ea', 1.0E0, N'', 'a2c4c8b3-3209-4a28-aa2c-520101a95ee2', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('8abc08f4-3959-45dc-874b-74c035c09173', 1.0E0, N'', 'e6b8015b-afde-42c1-b9f8-85287f5cfe7c', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('9272e1cd-5f09-44ee-abd4-ddbafc9bf0b4', 1.0E0, N'', 'b0810fd3-fbbc-4e09-a842-f166d0e02003', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('9647c2c6-b72d-4f3b-b2ea-3a3b1b3887e0', 1.0E0, N'', 'a934eaab-d760-4151-9f10-7041151768e7', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('a3ed9326-30d1-42f9-b0bb-3647487a2055', 1.0E0, N'', '8b8b18b3-3783-415b-a6f8-09d53a8d4dfc', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('a76a0673-22de-4686-a912-634e775d3834', 1.0E0, N'', '01b72770-ae8c-4388-9a18-cfd640e1d8c8', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('aa265174-8580-49ab-9a78-6ce010666833', 2.0E0, N'', 'c0865709-e77d-427a-bb00-f10d83de6a6f', '38b29f41-0757-4f98-af43-84394606eb03'),
('b792dc4b-48fa-4d2a-81fb-30b0f2e006f5', 1.0E0, N'', 'c957043d-fdd7-41e2-8943-d847f2b56d60', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('c2b7d7cb-7797-4ce2-b2cd-e2eebd367045', 1.0E0, N'', '582b7a4d-541b-4021-9b7b-8dbdbf73342e', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('c8c8451f-d087-4c79-af03-a84efe53d048', 1.0E0, N'', '1ba2a2b1-d3b4-44e3-844d-823eae6c8411', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('cff5519c-aac0-4156-9610-6efec7c5eda1', 1.0E0, N'', '9088fd3a-e9d2-4583-a02a-f57c075cfe9c', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('d00f5d67-5cf2-459f-b3f5-e1630958f9a0', 1.0E0, N'', '84c48d2c-842d-4b0d-8c9b-3264499f0f0f', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('d170edb5-bbaf-4edf-afe5-d2a8c05d380f', 1.0E0, N'', '55f73b90-e5c0-4153-9f4c-b5b688544da3', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('d9f48ffb-2348-49da-a5e3-e2a7e20c2ef5', 0.5E0, N'', '07e45ecc-4ed6-4372-bf7f-44f00ccca281', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('e672b853-0453-4c82-b709-38a45e860337', 1.0E0, N'', 'c5a5a200-b9aa-4ef8-b631-e959c325b5cb', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('ea250c7d-630c-4dfe-b77e-141d8ccdd5ec', 1.0E0, N'', 'e833429e-daee-4a9a-8625-cd0fef7d495d', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('f4e8350b-08cd-4cce-81c0-637f6bcb4af4', 2.0E0, N'', 'e991e259-b090-4db7-bf72-c1782d9c32ee', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaIngrediente', N'Cantidad', N'Detalle', N'IdIngrediente', N'IdReceta') AND [object_id] = OBJECT_ID(N'[RecetaIngrediente]'))
    SET IDENTITY_INSERT [RecetaIngrediente] OFF;

CREATE INDEX [IX_OrdenTrabajoCliente_IdContrato] ON [OrdenTrabajoCliente] ([IdContrato]);

CREATE INDEX [IX_Comida_IdContrato] ON [Comida] ([IdContrato]);

ALTER TABLE [Comida] ADD CONSTRAINT [FK_Comida_Contrato_IdContrato] FOREIGN KEY ([IdContrato]) REFERENCES [Contrato] ([IdContrato]);

ALTER TABLE [Comida] ADD CONSTRAINT [FK_Comida_OrdenTrabajo_IdOrdenTrabajo] FOREIGN KEY ([IdOrdenTrabajo]) REFERENCES [OrdenTrabajo] ([IdOrdenTrabajo]);

ALTER TABLE [OrdenTrabajoCliente] ADD CONSTRAINT [FK_OrdenTrabajoCliente_Contrato_IdContrato] FOREIGN KEY ([IdContrato]) REFERENCES [Contrato] ([IdContrato]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250628230917_AddContratoInOrdenFinalizada', N'9.0.3');

COMMIT;
GO