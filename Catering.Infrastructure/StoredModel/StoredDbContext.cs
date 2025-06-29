using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.Contratos;
using Catering.Domain.Ingredientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Infrastructure.DomainModel;
using Catering.Infrastructure.DomainModel.Config;
using Catering.Infrastructure.StoredModel.Entities;
using Joseco.Outbox.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel
{
    public class StoredDbContext : DbContext
    {
        public virtual DbSet<ClienteStoredModel> Cliente { get; set; }
        public virtual DbSet<ComidaStoredModel> Comida { get; set; }
        public virtual DbSet<ContratoStoredModel> Contrato { get; set; }
        public virtual DbSet<ContratoEntregaCanceladaStoredModel> ContratoEntregaCancelada { get; set; }
        public virtual DbSet<IngredienteStoredModel> Ingrediente { get; set; }
        public virtual DbSet<OrdenTrabajoClienteStoredModel> OrdenTrabajoCliente { get; set; }
        public virtual DbSet<OrdenTrabajoStoredModel> OrdenTrabajo { get; set; }
        public virtual DbSet<PlanAlimentarioRecetaStoredModel> PlanAlimentarioReceta { get; set; }
        public virtual DbSet<PlanAlimentarioStoredModel> PlanAlimentario { get; set; }
        public virtual DbSet<RecetaIngredienteStoredModel> RecetaIngrediente { get; set; }
        public virtual DbSet<RecetaInstruccionStoredModel> RecetaInstruccion { get; set; }
        public virtual DbSet<RecetaStoredModel> Receta { get; set; }
        public virtual DbSet<UsuarioStoredModel> Usuario { get; set; }

        public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
        {
        }

        public StoredDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddOutboxModel<DomainEvent>();

            // Seed data for Cliente
            var idCliente = Guid.Parse("9b971b55-e539-4939-9240-825a48402329");
            modelBuilder.Entity<ClienteStoredModel>().HasData(
                new ClienteStoredModel { Id = idCliente, Nombre = "Cliente Test" }
            );

            // Seed data for PlanAlimentario
            var idPlanAlimentario = Guid.Parse("b1c8f0d2-3c4e-4f5a-9b6c-7d8e9f0a1b2c");
            modelBuilder.Entity<PlanAlimentarioStoredModel>().HasData(
                new PlanAlimentarioStoredModel { Id = idPlanAlimentario, Nombre = "Plan Alimentario Test", Tipo = "Tipo del plan alimentario test", CantidadDias = 15 }
            );

            // Seed data for Contrato
            modelBuilder.Entity<ContratoStoredModel>().HasData(
                new ContratoStoredModel { Id = Guid.Parse("5faf7842-e7b5-4a3f-96c8-7719d01748b9"), IdCliente = idCliente, IdPlanAlimentario = idPlanAlimentario, DiasContratados = 15, DiasRealizados = 0, Estado = nameof(ContratoStatus.Iniciado), FechaInicio = DateTime.Today }
            );

            // Seed data for Ingrediente
            var ingredientesId = new Guid[35]
            {
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),
                Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid(),Guid.NewGuid()
            };
            modelBuilder.Entity<IngredienteStoredModel>().HasData(
                new IngredienteStoredModel { Id = ingredientesId[0], Nombre = "Brócoli", Medicion = "kg", Tipo = "Verdura", CostoCompra = 10.0m, CostoVenta = 15.0m },
                new IngredienteStoredModel { Id = ingredientesId[1], Nombre = "Zanahoria", Medicion = "kg", Tipo = "Verdura", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[2], Nombre = "Nueces", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[3], Nombre = "Aceite de oliva", Medicion = "litro", Tipo = "Aceite", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[4], Nombre = "Limón", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },

                new IngredienteStoredModel { Id = ingredientesId[5], Nombre = "Fideos", Medicion = "kg", Tipo = "Verdura", CostoCompra = 10.0m, CostoVenta = 15.0m },
                new IngredienteStoredModel { Id = ingredientesId[6], Nombre = "Hongos", Medicion = "kg", Tipo = "Verdura", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[7], Nombre = "Langostinos", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[8], Nombre = "Ajo", Medicion = "litro", Tipo = "Aceite", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[9], Nombre = "Huevos", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },

                new IngredienteStoredModel { Id = ingredientesId[10], Nombre = "Lentejas", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[11], Nombre = "Calabaza", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[12], Nombre = "Almendras", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[13], Nombre = "Aceite de oliva", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[14], Nombre = "Sal", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },

                new IngredienteStoredModel { Id = ingredientesId[15], Nombre = "Apio", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[16], Nombre = "Zanahoria", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[17], Nombre = "Puerro", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[18], Nombre = "Cebolla", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[19], Nombre = "Tomillo", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },

                new IngredienteStoredModel { Id = ingredientesId[20], Nombre = "Cuscús", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[21], Nombre = "Pechuga de pollo", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[22], Nombre = "Pimiento verde", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[23], Nombre = "Calabacín", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[24], Nombre = "Cúrcuma", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },

                new IngredienteStoredModel { Id = ingredientesId[25], Nombre = "Cebolla", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[26], Nombre = "Zanahoria", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[27], Nombre = "Brócoli", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[28], Nombre = "Jengibre fresco", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[29], Nombre = "Caldo de pollo bajo en sodio", Medicion = "lt", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },

                new IngredienteStoredModel { Id = ingredientesId[30], Nombre = "Pan integral", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[31], Nombre = "Palta", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[32], Nombre = "Huevo", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[33], Nombre = "Queso parmesano", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m },
                new IngredienteStoredModel { Id = ingredientesId[34], Nombre = "Hierbas frescas", Medicion = "kg", Tipo = "Fruta", CostoCompra = 5.0m, CostoVenta = 8.0m }
            );

            // Seed data for Receta
            var recetasId = new Guid[7]
            {
                Guid.Parse("38B29F41-0757-4F98-AF43-84394606EB03"),
                Guid.Parse("3D906EA7-E3A3-480D-B2CE-5B4F7586F227"),
                Guid.Parse("7F4423A6-F047-4759-B6BE-B9260F9D7E15"),
                Guid.Parse("ACF9388F-1AE9-4888-871A-720651408CF7"),
                Guid.Parse("3AA49ABB-9458-4097-8BC0-70118FE7E9F2"),
                Guid.Parse("0C18E665-5A64-4BA3-8903-999BB5C50D04"),
                Guid.Parse("FAAC0C33-64F8-4C92-840B-5C0D708719DF")
            };

            modelBuilder.Entity<RecetaStoredModel>().HasData(
                new RecetaStoredModel { Id = recetasId[0], Nombre = "Ensalada de brócoli, zanahoria y nueces" },
                new RecetaStoredModel { Id = recetasId[1], Nombre = "Fideos con revuelto de hongos y langostinos" },
                new RecetaStoredModel { Id = recetasId[2], Nombre = "Ensalada de lentejas con calabaza, hummus y almendras" },
                new RecetaStoredModel { Id = recetasId[3], Nombre = "Caldo de verduras rápido" },
                new RecetaStoredModel { Id = recetasId[4], Nombre = "Cuscús con pollo, verduras y cúrcuma" },
                new RecetaStoredModel { Id = recetasId[5], Nombre = "Sopa de pollo con vegetales" },
                new RecetaStoredModel { Id = recetasId[6], Nombre = "Tostada con palta y huevo escalfado" }
            );

            // Seed data for RecetaIngrediente
            modelBuilder.Entity<RecetaIngredienteStoredModel>().HasData(
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], IdIngrediente = ingredientesId[0], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], IdIngrediente = ingredientesId[1], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], IdIngrediente = ingredientesId[2], Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], IdIngrediente = ingredientesId[3], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], IdIngrediente = ingredientesId[4], Detalle = "", Cantidad = 2 },

                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], IdIngrediente = ingredientesId[5], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], IdIngrediente = ingredientesId[6], Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], IdIngrediente = ingredientesId[7], Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], IdIngrediente = ingredientesId[8], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], IdIngrediente = ingredientesId[9], Detalle = "", Cantidad = 1 },

                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], IdIngrediente = ingredientesId[10], Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], IdIngrediente = ingredientesId[11], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], IdIngrediente = ingredientesId[12], Detalle = "", Cantidad = 0.5 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], IdIngrediente = ingredientesId[13], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], IdIngrediente = ingredientesId[14], Detalle = "", Cantidad = 1 },

                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], IdIngrediente = ingredientesId[15], Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], IdIngrediente = ingredientesId[16], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], IdIngrediente = ingredientesId[17], Detalle = "", Cantidad = 0.5 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], IdIngrediente = ingredientesId[18], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], IdIngrediente = ingredientesId[19], Detalle = "", Cantidad = 1 },

                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], IdIngrediente = ingredientesId[20], Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], IdIngrediente = ingredientesId[21], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], IdIngrediente = ingredientesId[22], Detalle = "", Cantidad = 0.5 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], IdIngrediente = ingredientesId[23], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], IdIngrediente = ingredientesId[24], Detalle = "", Cantidad = 1 },

                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], IdIngrediente = ingredientesId[25], Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], IdIngrediente = ingredientesId[26], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], IdIngrediente = ingredientesId[27], Detalle = "", Cantidad = 0.5 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], IdIngrediente = ingredientesId[28], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], IdIngrediente = ingredientesId[29], Detalle = "", Cantidad = 1 },

                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], IdIngrediente = ingredientesId[30], Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], IdIngrediente = ingredientesId[31], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], IdIngrediente = ingredientesId[32], Detalle = "", Cantidad = 0.5 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], IdIngrediente = ingredientesId[33], Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], IdIngrediente = ingredientesId[34], Detalle = "", Cantidad = 1 }
            );

            // Seed data for RecetaInstruccion
            modelBuilder.Entity<RecetaInstruccionStoredModel>().HasData(
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], Instruccion = "1. Cocina el brócoli en agua con sal durante 5 minutos." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], Instruccion = "2. Ralla la zanahoria y mézclala con el brócoli." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], Instruccion = "3. Prepara una vinagreta con aceite de oliva y limón." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[0], Instruccion = "4. Pica las nueces y agrégalas a la ensalada." },

                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], Instruccion = "1. Cocina los fideos en agua hirviendo." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], Instruccion = "2. Dora el ajo en una sartén con aceite." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], Instruccion = "3. Agrega los hongos y saltéalos por 10 minutos." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], Instruccion = "4. Añade los langostinos y cocina hasta que estén dorados." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[1], Instruccion = "5. Incorpora los huevos batidos y revuelve hasta que cuajen." },

                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], Instruccion = "1. Cocina la calabaza y mézclala con las lentejas." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], Instruccion = "2. Pica las almendras y agrégalas." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], Instruccion = "3. Aliña con aceite de oliva y sal." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[2], Instruccion = "4. Sirve con hummus por encima." },

                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], Instruccion = "1. Pela y corta las verduras en trozos pequeños." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], Instruccion = "2. Saltea la cebolla y el puerro en una olla con aceite." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], Instruccion = "3. Agrega el resto de las verduras y cocina por 5 minutos." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], Instruccion = "4. Añade agua y hierbas aromáticas." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[3], Instruccion = "5. Cocina a fuego lento por 15 minutos y cuela el caldo." },

                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], Instruccion = "1. Cocina el cuscús según las instrucciones del paquete." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], Instruccion = "2. Saltea la cebolla picada hasta que esté dorada." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], Instruccion = "3. Agrega el pimiento, calabacín y pollo troceado." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], Instruccion = "4. Cocina hasta que el pollo esté bien cocido." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[4], Instruccion = "5. Mezcla con el cuscús y espolvorea cúrcuma." },

                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], Instruccion = "1. Cocina el pollo en una cacerola con un poco de aceite hasta dorarlo." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], Instruccion = "2. Agrega la cebolla y zanahoria picadas y sofríe por unos minutos." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], Instruccion = "3. Añade el caldo de pollo y deja hervir." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[5], Instruccion = "4. Incorpora el brócoli y el jengibre rallado. Cocina por 10 minutos." },

                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], Instruccion = "1. Tuesta el pan integral." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], Instruccion = "2. Machaca la palta y úntala sobre el pan." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], Instruccion = "3. Cocina el huevo escalfado y colócalo encima." },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = recetasId[6], Instruccion = "4. Espolvorea queso parmesano y hierbas frescas." }
            );

            // Seed data for Usuario
            modelBuilder.Entity<UsuarioStoredModel>().HasData(
                new UsuarioStoredModel { Id = Guid.Parse("d19a0e52-cf2a-45cb-a99f-7343afb296b4"), Nombre = "Usuario cocinero 1" },
                new UsuarioStoredModel { Id = Guid.Parse("76084be0-b170-44e8-a302-a4b7b34927d6"), Nombre = "Usuario cocinero 2" }
            );

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
