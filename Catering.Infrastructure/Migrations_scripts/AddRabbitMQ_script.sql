USE [Catering]

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

IF (SELECT MigrationId FROM [dbo].[__EFMigrationsHistory] WHERE MigrationId = '20250607040128_AddRabbitMQ') IS NOT NULL
	RETURN;

BEGIN TRANSACTION;

DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '75afd017-50b3-4feb-9aa1-6a0cc574da16';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '779f2031-c59a-4d99-a579-3b30fbc9d454';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = '85c16f52-56c3-4dba-ad45-ea4f5fe47cc4';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaIngrediente]
WHERE [IdRecetaIngrediente] = 'd390daf8-4432-4789-8620-a3f40713dfe4';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '1e055008-742c-4c3b-901b-f371156bfead';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '47eda952-9d17-45e6-a91d-7126290d8912';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '840c14b1-2aab-44b5-ba2e-336a17a4c38c';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '880fabc1-fc37-4940-8126-45f4ea076c00';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '99d49146-f040-4f66-b86b-237fec692687';
SELECT @@ROWCOUNT;


DELETE FROM [RecetaInstruccion]
WHERE [IdRecetaInstruccion] = '9b37bd7e-4cf2-4a38-b9bf-cc047d6d52c1';
SELECT @@ROWCOUNT;


IF SCHEMA_ID(N'outbox') IS NULL EXEC(N'CREATE SCHEMA [outbox];');

CREATE TABLE [outbox].[outboxMessage] (
    [outboxId] uniqueidentifier NOT NULL,
    [content] nvarchar(max) NULL,
    [type] nvarchar(max) NOT NULL,
    [created] datetime2 NOT NULL,
    [processed] bit NOT NULL,
    [processedOn] datetime2 NULL,
    [correlationId] nvarchar(max) NULL,
    [traceId] nvarchar(max) NULL,
    [spanId] nvarchar(max) NULL,
    CONSTRAINT [PK_outboxMessage] PRIMARY KEY ([outboxId])
);

CREATE TABLE [PlanAlimentario] (
    [IdPlanAlimentario] uniqueidentifier NOT NULL,
    [Nombre] nvarchar(250) NOT NULL,
    [Tipo] nvarchar(100) NOT NULL,
    [CantidadDias] int NOT NULL,
    CONSTRAINT [PK_PlanAlimentario] PRIMARY KEY ([IdPlanAlimentario])
);

CREATE TABLE [Contrato] (
    [IdContrato] uniqueidentifier NOT NULL,
    [IdCliente] uniqueidentifier NOT NULL,
    [IdPlanAlimentario] uniqueidentifier NOT NULL,
    [DiasContratados] int NOT NULL,
    [DiasRealizados] int NOT NULL,
    [Estado] nvarchar(25) NOT NULL,
    [FechaInicio] datetime2 NOT NULL,
    [FechaUltimoRealizado] datetime2 NULL,
    CONSTRAINT [PK_Contrato] PRIMARY KEY ([IdContrato]),
    CONSTRAINT [FK_Contrato_Cliente_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Cliente] ([IdCliente]),
    CONSTRAINT [FK_Contrato_PlanAlimentario_IdPlanAlimentario] FOREIGN KEY ([IdPlanAlimentario]) REFERENCES [PlanAlimentario] ([IdPlanAlimentario])
);

CREATE TABLE [PlanAlimentarioReceta] (
    [IdPlanAlimentarioReceta] uniqueidentifier NOT NULL,
    [IdPlanAlimentario] uniqueidentifier NOT NULL,
    [IdReceta] uniqueidentifier NOT NULL,
    [Dia] int NOT NULL,
    CONSTRAINT [PK_PlanAlimentarioReceta] PRIMARY KEY ([IdPlanAlimentarioReceta]),
    CONSTRAINT [FK_PlanAlimentarioReceta_PlanAlimentario_IdPlanAlimentario] FOREIGN KEY ([IdPlanAlimentario]) REFERENCES [PlanAlimentario] ([IdPlanAlimentario]) ON DELETE CASCADE,
    CONSTRAINT [FK_PlanAlimentarioReceta_Receta_IdReceta] FOREIGN KEY ([IdReceta]) REFERENCES [Receta] ([IdReceta]) ON DELETE CASCADE
);

CREATE TABLE [ContratoEntregaCancelada] (
    [IdContratoEntregaCancelada] uniqueidentifier NOT NULL,
    [IdContrato] uniqueidentifier NOT NULL,
    [FechaCancelada] datetime2 NOT NULL,
    CONSTRAINT [PK_ContratoEntregaCancelada] PRIMARY KEY ([IdContratoEntregaCancelada]),
    CONSTRAINT [FK_ContratoEntregaCancelada_Contrato_IdContrato] FOREIGN KEY ([IdContrato]) REFERENCES [Contrato] ([IdContrato])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaIngrediente', N'Cantidad', N'Detalle', N'IdIngrediente', N'IdReceta') AND [object_id] = OBJECT_ID(N'[RecetaIngrediente]'))
    SET IDENTITY_INSERT [RecetaIngrediente] ON;
INSERT INTO [RecetaIngrediente] ([IdRecetaIngrediente], [Cantidad], [Detalle], [IdIngrediente], [IdReceta])
VALUES ('01b0110b-61c8-4801-99c0-3620fdc0296b', 2.0E0, N'', 'c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50', '38b29f41-0757-4f98-af43-84394606eb03'),
('11d9ae1f-038b-4333-8be8-d63671975023', 1.0E0, N'', '74998d4d-4271-46df-a900-e3c8bcb9020a', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227'),
('6c422826-7f4e-4f8c-9121-4e82f1b6507a', 1.0E0, N'', '74998d4d-4271-46df-a900-e3c8bcb9020a', '38b29f41-0757-4f98-af43-84394606eb03'),
('7cd951f4-3dbc-4722-8ef0-aab8d56f0bb7', 2.0E0, N'', 'c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaIngrediente', N'Cantidad', N'Detalle', N'IdIngrediente', N'IdReceta') AND [object_id] = OBJECT_ID(N'[RecetaIngrediente]'))
    SET IDENTITY_INSERT [RecetaIngrediente] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] ON;
INSERT INTO [RecetaInstruccion] ([IdRecetaInstruccion], [IdReceta], [Instruccion])
VALUES ('00a5eaac-15a9-4347-9179-6042e567f421', '38b29f41-0757-4f98-af43-84394606eb03', N'Instruccion 1'),
('2205017b-20db-4522-b6b2-1046d188a702', '38b29f41-0757-4f98-af43-84394606eb03', N'Instruccion 2'),
('2ab2f382-8685-46a4-bc14-51f724a9b812', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'Instruccion 3'),
('76ff085d-2da7-4bb9-bcce-f9f7ccce1f79', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'Instruccion 1'),
('b2ef0456-2e9a-4f36-9ce0-064c5265e3d6', '3d906ea7-e3a3-480d-b2ce-5b4f7586f227', N'Instruccion 2'),
('b34b4bcc-2476-4c71-a961-0b448ce5cdc8', '38b29f41-0757-4f98-af43-84394606eb03', N'Instruccion 3');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdRecetaInstruccion', N'IdReceta', N'Instruccion') AND [object_id] = OBJECT_ID(N'[RecetaInstruccion]'))
    SET IDENTITY_INSERT [RecetaInstruccion] OFF;

CREATE INDEX [IX_Contrato_IdCliente] ON [Contrato] ([IdCliente]);

CREATE INDEX [IX_Contrato_IdPlanAlimentario] ON [Contrato] ([IdPlanAlimentario]);

CREATE INDEX [IX_ContratoEntregaCancelada_IdContrato] ON [ContratoEntregaCancelada] ([IdContrato]);

CREATE INDEX [IX_PlanAlimentarioReceta_IdPlanAlimentario] ON [PlanAlimentarioReceta] ([IdPlanAlimentario]);

CREATE INDEX [IX_PlanAlimentarioReceta_IdReceta] ON [PlanAlimentarioReceta] ([IdReceta]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250607040128_AddRabbitMQ', N'9.0.3');

COMMIT;
GO