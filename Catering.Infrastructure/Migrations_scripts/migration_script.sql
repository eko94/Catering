USE [Catering]

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

IF (SELECT MigrationId FROM [Catering].[dbo].[__EFMigrationsHistory] WHERE MigrationId = '20250222224817_InitialStoredDb') IS NOT NULL
	RETURN;

BEGIN TRANSACTION;

CREATE TABLE [Cliente] (
    [IdCliente] uniqueidentifier NOT NULL,
    [Nombre] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([IdCliente])
);

CREATE TABLE [Ingrediente] (
    [IdIngrediente] uniqueidentifier NOT NULL,
    [Nombre] nvarchar(250) NOT NULL,
    [Medicion] nvarchar(250) NOT NULL,
    [Tipo] nvarchar(250) NOT NULL,
    [CostoCompra] decimal(18,2) NOT NULL,
    [CostoVenta] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Ingrediente] PRIMARY KEY ([IdIngrediente])
);

CREATE TABLE [Receta] (
    [IdReceta] uniqueidentifier NOT NULL,
    [Nombre] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Receta] PRIMARY KEY ([IdReceta])
);

CREATE TABLE [Usuario] (
    [IdUsuario] uniqueidentifier NOT NULL,
    [Nombre] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([IdUsuario])
);

CREATE TABLE [RecetaIngrediente] (
    [IdRecetaIngrediente] uniqueidentifier NOT NULL,
    [IdReceta] uniqueidentifier NOT NULL,
    [IdIngrediente] uniqueidentifier NOT NULL,
    [Detalle] nvarchar(250) NOT NULL,
    [Cantidad] float NOT NULL,
    CONSTRAINT [PK_RecetaIngrediente] PRIMARY KEY ([IdRecetaIngrediente]),
    CONSTRAINT [FK_RecetaIngrediente_Ingrediente_IdIngrediente] FOREIGN KEY ([IdIngrediente]) REFERENCES [Ingrediente] ([IdIngrediente]) ON DELETE CASCADE,
    CONSTRAINT [FK_RecetaIngrediente_Receta_IdReceta] FOREIGN KEY ([IdReceta]) REFERENCES [Receta] ([IdReceta]) ON DELETE CASCADE
);

CREATE TABLE [RecetaInstruccion] (
    [IdRecetaInstruccion] uniqueidentifier NOT NULL,
    [IdReceta] uniqueidentifier NOT NULL,
    [Instruccion] nvarchar(250) NOT NULL,
    CONSTRAINT [PK_RecetaInstruccion] PRIMARY KEY ([IdRecetaInstruccion]),
    CONSTRAINT [FK_RecetaInstruccion_Receta_IdReceta] FOREIGN KEY ([IdReceta]) REFERENCES [Receta] ([IdReceta]) ON DELETE CASCADE
);

CREATE TABLE [OrdenTrabajo] (
    [IdOrdenTrabajo] uniqueidentifier NOT NULL,
    [IdUsuarioCocinero] uniqueidentifier NOT NULL,
    [IdReceta] uniqueidentifier NOT NULL,
    [Cantidad] int NOT NULL,
    [Estado] nvarchar(25) NOT NULL,
    [Tipo] nvarchar(25) NOT NULL,
    [FechaCreado] datetime2 NOT NULL,
    CONSTRAINT [PK_OrdenTrabajo] PRIMARY KEY ([IdOrdenTrabajo]),
    CONSTRAINT [FK_OrdenTrabajo_Receta_IdReceta] FOREIGN KEY ([IdReceta]) REFERENCES [Receta] ([IdReceta]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrdenTrabajo_Usuario_IdUsuarioCocinero] FOREIGN KEY ([IdUsuarioCocinero]) REFERENCES [Usuario] ([IdUsuario]) ON DELETE CASCADE
);

CREATE TABLE [Comida] (
    [IdComida] uniqueidentifier NOT NULL,
    [Nombre] nvarchar(250) NOT NULL,
    [Estado] nvarchar(25) NOT NULL,
    [IdCliente] uniqueidentifier NULL,
    [IdOrdenTrabajo] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Comida] PRIMARY KEY ([IdComida]),
    CONSTRAINT [FK_Comida_Cliente_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Cliente] ([IdCliente]),
    CONSTRAINT [FK_Comida_OrdenTrabajo_IdOrdenTrabajo] FOREIGN KEY ([IdOrdenTrabajo]) REFERENCES [OrdenTrabajo] ([IdOrdenTrabajo]) ON DELETE CASCADE
);

CREATE TABLE [OrdenTrabajoCliente] (
    [IdOrdenTrabajoCliente] uniqueidentifier NOT NULL,
    [IdOrdenTrabajo] uniqueidentifier NOT NULL,
    [IdCliente] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_OrdenTrabajoCliente] PRIMARY KEY ([IdOrdenTrabajoCliente]),
    CONSTRAINT [FK_OrdenTrabajoCliente_Cliente_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Cliente] ([IdCliente]) ON DELETE CASCADE,
    CONSTRAINT [FK_OrdenTrabajoCliente_OrdenTrabajo_IdOrdenTrabajo] FOREIGN KEY ([IdOrdenTrabajo]) REFERENCES [OrdenTrabajo] ([IdOrdenTrabajo]) ON DELETE CASCADE
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdCliente', N'Nombre') AND [object_id] = OBJECT_ID(N'[Cliente]'))
    SET IDENTITY_INSERT [Cliente] ON;
INSERT INTO [Cliente] ([IdCliente], [Nombre])
VALUES ('9b971b55-e539-4939-9240-825a48402329', N'Cliente 1'),
('a71010c7-979b-4217-a899-c1c3d8179f4a', N'Cliente 2');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdCliente', N'Nombre') AND [object_id] = OBJECT_ID(N'[Cliente]'))
    SET IDENTITY_INSERT [Cliente] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdIngrediente', N'CostoCompra', N'CostoVenta', N'Medicion', N'Nombre', N'Tipo') AND [object_id] = OBJECT_ID(N'[Ingrediente]'))
    SET IDENTITY_INSERT [Ingrediente] ON;
INSERT INTO [Ingrediente] ([IdIngrediente], [CostoCompra], [CostoVenta], [Medicion], [Nombre], [Tipo])
VALUES ('74998d4d-4271-46df-a900-e3c8bcb9020a', 10.0, 15.0, N'kg', N'Ingrediente 1', N'Tipo 1'),
('c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50', 5.0, 8.0, N'litro', N'Ingrediente 2', N'Tipo 2');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdIngrediente', N'CostoCompra', N'CostoVenta', N'Medicion', N'Nombre', N'Tipo') AND [object_id] = OBJECT_ID(N'[Ingrediente]'))
    SET IDENTITY_INSERT [Ingrediente] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdReceta', N'Nombre') AND [object_id] = OBJECT_ID(N'[Receta]'))
    SET IDENTITY_INSERT [Receta] ON;
INSERT INTO [Receta] ([IdReceta], [Nombre])
VALUES ('38b29f41-0757-4f98-af43-84394606eb03', N'Receta 1'),
('3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'Receta 2');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdReceta', N'Nombre') AND [object_id] = OBJECT_ID(N'[Receta]'))
    SET IDENTITY_INSERT [Receta] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'Nombre') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] ON;
INSERT INTO [Usuario] ([IdUsuario], [Nombre])
VALUES ('76084be0-b170-44e8-a302-a4b7b34927d6', N'Usuario cocinero 2'),
('d19a0e52-cf2a-45cb-a99f-7343afb296b4', N'Usuario cocinero 1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'Nombre') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaIngrediente', N'Cantidad', N'Detalle', N'IdIngrediente', N'IdReceta') AND [object_id] = OBJECT_ID(N'[RecetaIngrediente]'))
    SET IDENTITY_INSERT [RecetaIngrediente] ON;
INSERT INTO [RecetaIngrediente] ([IdRecetaIngrediente], [Cantidad], [Detalle], [IdIngrediente], [IdReceta])
VALUES ('75afd017-50b3-4feb-9aa1-6a0cc574da16', 1.0E0, N'', '74998d4d-4271-46df-a900-e3c8bcb9020a', '38b29f41-0757-4f98-af43-84394606eb03'),
('779f2031-c59a-4d99-a579-3b30fbc9d454', 1.0E0, N'', '74998d4d-4271-46df-a900-e3c8bcb9020a', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('85c16f52-56c3-4dba-ad45-ea4f5fe47cc4', 2.0E0, N'', 'c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('d390daf8-4432-4789-8620-a3f40713dfe4', 2.0E0, N'', 'c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50', '38b29f41-0757-4f98-af43-84394606eb03');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaIngrediente', N'Cantidad', N'Detalle', N'IdIngrediente', N'IdReceta') AND [object_id] = OBJECT_ID(N'[RecetaIngrediente]'))
    SET IDENTITY_INSERT [RecetaIngrediente] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] ON;
INSERT INTO [RecetaInstruccion] ([IdRecetaInstruccion], [IdReceta], [Instruccion])
VALUES ('1e055008-742c-4c3b-901b-f371156bfead', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'Instruccion 3'),
('47eda952-9d17-45e6-a91d-7126290d8912', '38b29f41-0757-4f98-af43-84394606eb03', N'Instruccion 2'),
('840c14b1-2aab-44b5-ba2e-336a17a4c38c', '38b29f41-0757-4f98-af43-84394606eb03', N'Instruccion 1'),
('880fabc1-fc37-4940-8126-45f4ea076c00', '38b29f41-0757-4f98-af43-84394606eb03', N'Instruccion 3'),
('99d49146-f040-4f66-b86b-237fec692687', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'Instruccion 1'),
('9b37bd7e-4cf2-4a38-b9bf-cc047d6d52c1', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'Instruccion 2');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] OFF;

CREATE INDEX [IX_Comida_IdCliente] ON [Comida] ([IdCliente]);

CREATE INDEX [IX_Comida_IdOrdenTrabajo] ON [Comida] ([IdOrdenTrabajo]);

CREATE INDEX [IX_OrdenTrabajo_IdReceta] ON [OrdenTrabajo] ([IdReceta]);

CREATE INDEX [IX_OrdenTrabajo_IdUsuarioCocinero] ON [OrdenTrabajo] ([IdUsuarioCocinero]);

CREATE INDEX [IX_OrdenTrabajoCliente_IdCliente] ON [OrdenTrabajoCliente] ([IdCliente]);

CREATE INDEX [IX_OrdenTrabajoCliente_IdOrdenTrabajo] ON [OrdenTrabajoCliente] ([IdOrdenTrabajo]);

CREATE INDEX [IX_RecetaIngrediente_IdIngrediente] ON [RecetaIngrediente] ([IdIngrediente]);

CREATE INDEX [IX_RecetaIngrediente_IdReceta] ON [RecetaIngrediente] ([IdReceta]);

CREATE INDEX [IX_RecetaInstruccion_IdReceta] ON [RecetaInstruccion] ([IdReceta]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250222224817_InitialStoredDb', N'9.0.0');

COMMIT;
GO

