USE [Catering]

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

IF (SELECT MigrationId FROM [Catering].[dbo].[__EFMigrationsHistory] WHERE MigrationId = '20250608043546_AddRecetas') IS NOT NULL
	RETURN;

BEGIN TRANSACTION;

DELETE FROM [Cliente]
WHERE [IdCliente] = 'a71010c7-979b-4217-a899-c1c3d8179f4a';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '01b0110b-61c8-4801-99c0-3620fdc0296b';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '11d9ae1f-038b-4333-8be8-d63671975023';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '6c422826-7f4e-4f8c-9121-4e82f1b6507a';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '7cd951f4-3dbc-4722-8ef0-aab8d56f0bb7';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '00a5eaac-15a9-4347-9179-6042e567f421';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '2205017b-20db-4522-b6b2-1046d188a702';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '2ab2f382-8685-46a4-bc14-51f724a9b812';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '76ff085d-2da7-4bb9-bcce-f9f7ccce1f79';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'b2ef0456-2e9a-4f36-9ce0-064c5265e3d6';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = 'b34b4bcc-2476-4c71-a961-0b448ce5cdc8';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = '74998d4d-4271-46df-a900-e3c8bcb9020a';
SELECT @@ROWCOUNT;


DELETE FROM [Ingrediente]
WHERE [IdIngrediente] = 'c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50';
SELECT @@ROWCOUNT;


UPDATE [Cliente] SET [Nombre] = N'Cliente Test'
WHERE [IdCliente] = '9b971b55-e539-4939-9240-825a48402329';
SELECT @@ROWCOUNT;


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdIngrediente', N'CostoCompra', N'CostoVenta', N'Medicion', N'Nombre', N'Tipo') AND [object_id] = OBJECT_ID(N'[Ingrediente]'))
    SET IDENTITY_INSERT [Ingrediente] ON;
INSERT INTO [Ingrediente] ([IdIngrediente], [CostoCompra], [CostoVenta], [Medicion], [Nombre], [Tipo])
VALUES ('06039340-c688-4198-be53-9b121b8b6095', 5.0, 8.0, N'kg', N'Brócoli', N'Fruta'),
('0745f464-037e-480b-be23-03e496455b07', 5.0, 8.0, N'kg', N'Calabaza', N'Fruta'),
('0e2c4760-659c-461b-b5a4-625f977006bb', 5.0, 8.0, N'kg', N'Zanahoria', N'Fruta'),
('12aa9ee3-bd3c-484c-a884-3e3c15f41ead', 10.0, 15.0, N'kg', N'Fideos', N'Verdura'),
('19463210-1541-4657-b434-40cbbe632ad0', 5.0, 8.0, N'kg', N'Langostinos', N'Fruta'),
('2c769505-6d43-4c97-b41f-932ad482e392', 5.0, 8.0, N'kg', N'Nueces', N'Fruta'),
('2dac2664-b05a-4d3d-a1fb-6484cf974040', 5.0, 8.0, N'kg', N'Pan integral', N'Fruta'),
('3118439c-0fed-48f2-8360-7aa88c54c5fc', 5.0, 8.0, N'kg', N'Pechuga de pollo', N'Fruta'),
('32f0b892-9b46-422e-b150-0371fcd53c3a', 5.0, 8.0, N'kg', N'Hongos', N'Verdura'),
('3ed4a2b6-0e34-42f8-a09a-6ea9c7cc4cd7', 5.0, 8.0, N'kg', N'Queso parmesano', N'Fruta'),
('44b773af-e296-4e3c-b14d-e2666a9ec9d0', 5.0, 8.0, N'kg', N'Zanahoria', N'Verdura'),
('4dabd6cb-1f9b-472d-af4d-b4d33a8f5b05', 5.0, 8.0, N'litro', N'Ajo', N'Aceite'),
('4db4c7f2-d408-4cd0-9158-1274da111e09', 5.0, 8.0, N'kg', N'Puerro', N'Fruta'),
('56b8e3f1-1d7f-4def-9701-5c1897d615bf', 5.0, 8.0, N'kg', N'Apio', N'Fruta'),
('57926f10-5803-45f6-91f0-17d0da6da8d9', 5.0, 8.0, N'kg', N'Cebolla', N'Fruta'),
('5c6f43b5-4cea-44a8-bd2f-a9b10d2d8767', 5.0, 8.0, N'kg', N'Huevos', N'Fruta'),
('67187905-2b25-4506-a130-80a27c14657a', 5.0, 8.0, N'kg', N'Jengibre fresco', N'Fruta'),
('6a5749df-d4dc-41c0-b6ab-8695818fc9e6', 10.0, 15.0, N'kg', N'Brócoli', N'Verdura'),
('70b99e59-1771-4e65-8089-ffac97b1d6f3', 5.0, 8.0, N'kg', N'Lentejas', N'Fruta'),
('77fe8568-533f-44dd-b1bf-945e688ecd3a', 5.0, 8.0, N'kg', N'Aceite de oliva', N'Fruta'),
('7e976679-6260-4ddc-bdaf-1893f97b49a2', 5.0, 8.0, N'kg', N'Sal', N'Fruta'),
('8086a17c-8982-46e2-ac9b-1daaeb851511', 5.0, 8.0, N'kg', N'Calabacín', N'Fruta'),
('86c608c6-a760-45c1-a0fd-3f5be3e80e0f', 5.0, 8.0, N'kg', N'Zanahoria', N'Fruta'),
('98984a30-ca54-409b-8414-5d63f874990b', 5.0, 8.0, N'kg', N'Cebolla', N'Fruta'),
('9e2a9322-8141-4217-9676-f0854e6be3bb', 5.0, 8.0, N'lt', N'Caldo de pollo bajo en sodio', N'Fruta'),
('ab285967-94c6-48a2-b66d-42971e3054ae', 5.0, 8.0, N'kg', N'Almendras', N'Fruta'),
('b0a2dd75-e553-4449-8361-4fdde9dd5cd9', 5.0, 8.0, N'kg', N'Cúrcuma', N'Fruta'),
('d8b1ac8c-ff87-4f98-bb99-01a74e468068', 5.0, 8.0, N'litro', N'Aceite de oliva', N'Aceite'),
('defe0a39-59e9-4700-85b1-fbcfd707ecd8', 5.0, 8.0, N'kg', N'Palta', N'Fruta'),
('df14fcb6-b47c-4a1e-b168-fea14acd34e9', 5.0, 8.0, N'kg', N'Hierbas frescas', N'Fruta'),
('ec8e74f0-0374-458d-bddf-aca570199fdf', 5.0, 8.0, N'kg', N'Limón', N'Fruta'),
('eeb37d25-bed5-47df-895b-d1d71991ba41', 5.0, 8.0, N'kg', N'Pimiento verde', N'Fruta'),
('f81da1c8-3a09-435a-98bd-a57f01c4bd88', 5.0, 8.0, N'kg', N'Huevo', N'Fruta'),
('fa650ba6-9eaa-4f17-96a4-4a389587e958', 5.0, 8.0, N'kg', N'Tomillo', N'Fruta'),
('fec95a30-bf71-431e-867e-8e772ba4111e', 5.0, 8.0, N'kg', N'Cuscús', N'Fruta');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdIngrediente', N'CostoCompra', N'CostoVenta', N'Medicion', N'Nombre', N'Tipo') AND [object_id] = OBJECT_ID(N'[Ingrediente]'))
    SET IDENTITY_INSERT [Ingrediente] OFF;

UPDATE [Receta] SET [Nombre] = N'Ensalada de brócoli, zanahoria y nueces'
WHERE [IdReceta] = '38b29f41-0757-4f98-af43-84394606eb03';
SELECT @@ROWCOUNT;


UPDATE [Receta] SET [Nombre] = N'Fideos con revuelto de hongos y langostinos'
WHERE [IdReceta] = '3d906ea7-e3a3-480d-b2ce-5b4f7586f227';
SELECT @@ROWCOUNT;


IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdReceta', N'Nombre') AND [object_id] = OBJECT_ID(N'[Receta]'))
    SET IDENTITY_INSERT [Receta] ON;
INSERT INTO [Receta] ([IdReceta], [Nombre])
VALUES ('0c18e665-5a64-4ba3-8903-999bb5c50d04', N'Sopa de pollo con vegetales'),
('3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'Cuscús con pollo, verduras y cúrcuma'),
('7f4423a6-f047-4759-b6be-b9260f9d7e15', N'Ensalada de lentejas con calabaza, hummus y almendras'),
('acf9388f-1ae9-4888-871a-720651408cf7', N'Caldo de verduras rápido'),
('faac0c33-64f8-4c92-840b-5c0d708719df', N'Tostada con palta y huevo escalfado');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdReceta', N'Nombre') AND [object_id] = OBJECT_ID(N'[Receta]'))
    SET IDENTITY_INSERT [Receta] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] ON;
INSERT INTO [RecetaInstruccion] ([IdRecetaInstruccion], [IdReceta], [Instruccion])
VALUES ('0413cadb-11f8-40ee-82bd-3519d20233a7', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'3. Agrega los hongos y saltéalos por 10 minutos.'),
('30ff4ce5-06b5-45e1-84c6-8a941588fcd5', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'4. Añade los langostinos y cocina hasta que estén dorados.'),
('59a7382e-7091-4ff1-9e69-38daaee7f6d6', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'5. Incorpora los huevos batidos y revuelve hasta que cuajen.'),
('bcc129e2-d309-4828-82c7-edb1b9613c39', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'2. Dora el ajo en una sartén con aceite.'),
('c3d6adb5-71c3-4d26-a516-fb2d6147918c', '38b29f41-0757-4f98-af43-84394606eb03', N'3. Prepara una vinagreta con aceite de oliva y limón.'),
('deb42c99-787c-4051-bf2c-7428e56940f3', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'1. Cocina los fideos en agua hirviendo.'),
('e3b91da5-e0f6-4fd6-905c-b17b76c817c2', '38b29f41-0757-4f98-af43-84394606eb03', N'2. Ralla la zanahoria y mézclala con el brócoli.'),
('f4c716df-d287-43c1-a3e2-ffb7dd1bc698', '38b29f41-0757-4f98-af43-84394606eb03', N'4. Pica las nueces y agrégalas a la ensalada.'),
('fd0b4eef-c47b-429d-92c6-2a84027ffd92', '38b29f41-0757-4f98-af43-84394606eb03', N'1. Cocina el brócoli en agua con sal durante 5 minutos.');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaIngrediente', N'Cantidad', N'Detalle', N'IdIngrediente', N'IdReceta') AND [object_id] = OBJECT_ID(N'[RecetaIngrediente]'))
    SET IDENTITY_INSERT [RecetaIngrediente] ON;
INSERT INTO [RecetaIngrediente] ([IdRecetaIngrediente], [Cantidad], [Detalle], [IdIngrediente], [IdReceta])
VALUES ('166a1ed5-daef-4475-9c7f-ec25dbb2b33f', 1.0E0, N'', '3118439c-0fed-48f2-8360-7aa88c54c5fc', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('3028a30f-d3b4-47f4-af18-0f89324fffbe', 2.0E0, N'', '2c769505-6d43-4c97-b41f-932ad482e392', '38b29f41-0757-4f98-af43-84394606eb03'),
('30e45c75-bf1f-4341-b4ae-03b8cee6e789', 1.0E0, N'', '5c6f43b5-4cea-44a8-bd2f-a9b10d2d8767', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('3f5d575b-15fe-415b-a697-60e234f7f52c', 1.0E0, N'', '67187905-2b25-4506-a130-80a27c14657a', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('3fffac45-8a06-4556-bda9-8fca0eccf11b', 2.0E0, N'', 'ec8e74f0-0374-458d-bddf-aca570199fdf', '38b29f41-0757-4f98-af43-84394606eb03'),
('40c0485a-9790-4c68-8a31-f2041485c895', 1.0E0, N'', 'defe0a39-59e9-4700-85b1-fbcfd707ecd8', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('486738dd-3b9c-48bd-ba60-aeeec60d7c8f', 0.5E0, N'', 'ab285967-94c6-48a2-b66d-42971e3054ae', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('59cdbb6f-68e7-494b-bc5d-41b860e0e60c', 1.0E0, N'', '77fe8568-533f-44dd-b1bf-945e688ecd3a', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('5ab78f81-87d2-498e-94f1-231aa8dfa5bf', 1.0E0, N'', '6a5749df-d4dc-41c0-b6ab-8695818fc9e6', '38b29f41-0757-4f98-af43-84394606eb03'),
('5b7d3848-9e4a-4063-8861-41d234f2381d', 2.0E0, N'', '56b8e3f1-1d7f-4def-9701-5c1897d615bf', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('6160026e-9a9f-482b-8afb-7ac04dd55c15', 1.0E0, N'', '7e976679-6260-4ddc-bdaf-1893f97b49a2', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('65548f1b-feba-40e0-8a91-a363319c9041', 1.0E0, N'', '57926f10-5803-45f6-91f0-17d0da6da8d9', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('6e392090-fd95-4405-ac36-409ec4759a42', 1.0E0, N'', '0745f464-037e-480b-be23-03e496455b07', '7f4423a6-f047-4759-b6be-b9260f9d7e15'),
('716b380b-1bee-4629-b09e-9f1ba06a7f97', 2.0E0, N'', '19463210-1541-4657-b434-40cbbe632ad0', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('72db7bc6-a6d6-4f11-864c-8f382a2c266d', 0.5E0, N'', 'eeb37d25-bed5-47df-895b-d1d71991ba41', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('8195bdbc-00a0-4917-8ce5-8dc0986106c2', 1.0E0, N'', '12aa9ee3-bd3c-484c-a884-3e3c15f41ead', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('84072b97-77c9-4ccb-9b9b-d29ede40db54', 1.0E0, N'', 'fa650ba6-9eaa-4f17-96a4-4a389587e958', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('93127af8-53be-4935-a33a-44c8bf6d6fea', 2.0E0, N'', '32f0b892-9b46-422e-b150-0371fcd53c3a', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('9742cbf8-4db4-4605-9c6f-e9fada719add', 0.5E0, N'', '4db4c7f2-d408-4cd0-9158-1274da111e09', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('9cb5baaa-1c99-4101-81f9-3ced1057b715', 1.0E0, N'', 'b0a2dd75-e553-4449-8361-4fdde9dd5cd9', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('9e874ca6-76dd-41d1-bbf3-809585eb29ae', 0.5E0, N'', 'f81da1c8-3a09-435a-98bd-a57f01c4bd88', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('a8fffd2d-4255-47ef-a0e8-8922d5178b32', 1.0E0, N'', '3ed4a2b6-0e34-42f8-a09a-6ea9c7cc4cd7', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('ac457561-0556-4c8b-a886-9b6e095cfcc1', 1.0E0, N'', '0e2c4760-659c-461b-b5a4-625f977006bb', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('ad97edc6-71fd-44d9-ae11-b9cca918308b', 1.0E0, N'', '9e2a9322-8141-4217-9676-f0854e6be3bb', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('b4030821-5d3d-48b9-b19c-4d0b741717a8', 1.0E0, N'', '86c608c6-a760-45c1-a0fd-3f5be3e80e0f', 'acf9388f-1ae9-4888-871a-720651408cf7'),
('b913dea9-e201-42d5-b800-7d8ee5269245', 1.0E0, N'', 'd8b1ac8c-ff87-4f98-bb99-01a74e468068', '38b29f41-0757-4f98-af43-84394606eb03'),
('baff6777-24ab-49ea-9433-0514ffd94f6f', 1.0E0, N'', 'df14fcb6-b47c-4a1e-b168-fea14acd34e9', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('bfc9ca35-e128-4e40-abbe-b1877bd1b3d4', 1.0E0, N'', '4dabd6cb-1f9b-472d-af4d-b4d33a8f5b05', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('c31db85c-e0bb-4497-92d1-06be898bfcb7', 0.5E0, N'', '06039340-c688-4198-be53-9b121b8b6095', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('c8fff2ed-f9bd-4784-b37d-98001112329a', 1.0E0, N'', '8086a17c-8982-46e2-ac9b-1daaeb851511', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('db320652-02b5-4b56-b27f-1b1ce746e6f3', 2.0E0, N'', 'fec95a30-bf71-431e-867e-8e772ba4111e', '3aa49abb-9458-4097-8bc0-70118fe7e9f2'),
('dd0ec80c-ccd2-412e-bcd9-d91c3b8253e2', 2.0E0, N'', '2dac2664-b05a-4d3d-a1fb-6484cf974040', 'faac0c33-64f8-4c92-840b-5c0d708719df'),
('e2b2ece3-d813-4414-a72f-77e35f54c1dc', 2.0E0, N'', '98984a30-ca54-409b-8414-5d63f874990b', '0c18e665-5a64-4ba3-8903-999bb5c50d04'),
('eaba08a6-c753-43f8-b9db-5d7ea87eb839', 1.0E0, N'', '44b773af-e296-4e3c-b14d-e2666a9ec9d0', '38b29f41-0757-4f98-af43-84394606eb03'),
('fbd088e2-e31b-4b08-b2d8-5e8f35bfa6be', 2.0E0, N'', '70b99e59-1771-4e65-8089-ffac97b1d6f3', '7f4423a6-f047-4759-b6be-b9260f9d7e15');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaIngrediente', N'Cantidad', N'Detalle', N'IdIngrediente', N'IdReceta') AND [object_id] = OBJECT_ID(N'[RecetaIngrediente]'))
    SET IDENTITY_INSERT [RecetaIngrediente] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] ON;
INSERT INTO [RecetaInstruccion] ([IdRecetaInstruccion], [IdReceta], [Instruccion])
VALUES ('0476c087-ae00-4995-bef4-b1bb5622ae35', 'acf9388f-1ae9-4888-871a-720651408cf7', N'1. Pela y corta las verduras en trozos pequeños.'),
('0d6464de-cb60-4ab2-b996-12bb3efac8cd', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'1. Cocina el cuscús según las instrucciones del paquete.'),
('0ed37ae3-7200-4f57-a9a3-926af7723a30', 'acf9388f-1ae9-4888-871a-720651408cf7', N'2. Saltea la cebolla y el puerro en una olla con aceite.'),
('0eeaa4e4-f78a-40ac-b4bd-f9675e859ca3', '0c18e665-5a64-4ba3-8903-999bb5c50d04', N'4. Incorpora el brócoli y el jengibre rallado. Cocina por 10 minutos.'),
('1f820b52-f93c-4494-a466-9dbe9b9f4173', '7f4423a6-f047-4759-b6be-b9260f9d7e15', N'2. Pica las almendras y agrégalas.'),
('287aa52a-1cd7-46c2-ab20-b2881904623b', '7f4423a6-f047-4759-b6be-b9260f9d7e15', N'1. Cocina la calabaza y mézclala con las lentejas.'),
('37e39156-d452-406f-a968-9329a3d2fbfe', 'acf9388f-1ae9-4888-871a-720651408cf7', N'3. Agrega el resto de las verduras y cocina por 5 minutos.'),
('47522d10-132b-4e1e-8e62-e0504f3383f5', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'4. Cocina hasta que el pollo esté bien cocido.'),
('490efb22-ea42-4357-a52e-32144bcffeec', '7f4423a6-f047-4759-b6be-b9260f9d7e15', N'4. Sirve con hummus por encima.'),
('59939db8-0718-4049-add9-fd34fb96e0c1', '0c18e665-5a64-4ba3-8903-999bb5c50d04', N'2. Agrega la cebolla y zanahoria picadas y sofríe por unos minutos.'),
('83af7ebe-12e0-447e-a4c6-65ab24f18c0c', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'3. Agrega el pimiento, calabacín y pollo troceado.'),
('b857ef2b-5cd6-495d-8b89-a027136d5daf', 'acf9388f-1ae9-4888-871a-720651408cf7', N'5. Cocina a fuego lento por 15 minutos y cuela el caldo.'),
('c1bc7018-0d4a-4901-b447-ba2e42fa9e64', '0c18e665-5a64-4ba3-8903-999bb5c50d04', N'3. Añade el caldo de pollo y deja hervir.'),
('ceb44330-9b85-4864-9704-3cbcc80d2324', 'faac0c33-64f8-4c92-840b-5c0d708719df', N'2. Machaca la palta y úntala sobre el pan.'),
('d36861c3-4df9-485e-b896-0ed3f12ee29f', 'acf9388f-1ae9-4888-871a-720651408cf7', N'4. Añade agua y hierbas aromáticas.'),
('d38600da-f740-4e0a-949f-a5bab086840f', 'faac0c33-64f8-4c92-840b-5c0d708719df', N'4. Espolvorea queso parmesano y hierbas frescas.'),
('ddd33118-7eb5-42d0-8bd9-571aa00c7983', '7f4423a6-f047-4759-b6be-b9260f9d7e15', N'3. Aliña con aceite de oliva y sal.'),
('e20d1170-072b-4697-8626-b108849d4001', '0c18e665-5a64-4ba3-8903-999bb5c50d04', N'1. Cocina el pollo en una cacerola con un poco de aceite hasta dorarlo.'),
('e2a8025e-8ded-41e6-ba08-8d5152d95808', 'faac0c33-64f8-4c92-840b-5c0d708719df', N'3. Cocina el huevo escalfado y colócalo encima.'),
('e54802df-bec4-4fd7-9570-d7c79c19b30f', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'5. Mezcla con el cuscús y espolvorea cúrcuma.'),
('eb4ff17c-eae8-4569-b535-aeff70903141', 'faac0c33-64f8-4c92-840b-5c0d708719df', N'1. Tuesta el pan integral.'),
('f27a3e6e-a4b5-4a5a-88a2-67ae0f2a346e', '3aa49abb-9458-4097-8bc0-70118fe7e9f2', N'2. Saltea la cebolla picada hasta que esté dorada.');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] OFF;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250608043546_AddRecetas', N'9.0.3');

COMMIT;
GO