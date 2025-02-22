using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Infrastructure.DomainModel;
using Catering.Infrastructure.DomainModel.Config;
using Catering.Infrastructure.StoredModel.Entities;
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
        public virtual DbSet<IngredienteStoredModel> Ingrediente { get; set; }
        public virtual DbSet<OrdenTrabajoClienteStoredModel> OrdenTrabajoCliente { get; set; }
        public virtual DbSet<OrdenTrabajoStoredModel> OrdenTrabajo { get; set; }
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

            // Seed data for Cliente
            modelBuilder.Entity<ClienteStoredModel>().HasData(
                new ClienteStoredModel { Id = Guid.Parse("9b971b55-e539-4939-9240-825a48402329"), Nombre = "Cliente 1" },
                new ClienteStoredModel { Id = Guid.Parse("a71010c7-979b-4217-a899-c1c3d8179f4a"), Nombre = "Cliente 2" }
            );

            // Seed data for Ingrediente
            modelBuilder.Entity<IngredienteStoredModel>().HasData(
                new IngredienteStoredModel { Id = Guid.Parse("74998d4d-4271-46df-a900-e3c8bcb9020a"), Nombre = "Ingrediente 1", Medicion = "kg", Tipo = "Tipo 1", CostoCompra = 10.0m, CostoVenta = 15.0m },
                new IngredienteStoredModel { Id = Guid.Parse("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), Nombre = "Ingrediente 2", Medicion = "litro", Tipo = "Tipo 2", CostoCompra = 5.0m, CostoVenta = 8.0m }
            );

            // Seed data for Receta
            var receta1Id = Guid.Parse("38b29f41-0757-4f98-af43-84394606eb03");
            var receta2Id = Guid.Parse("3d906ea7-e3a3-480d-b2ce-5b4f7586f227");

            modelBuilder.Entity<RecetaStoredModel>().HasData(
                new RecetaStoredModel { Id = receta1Id, Nombre = "Receta 1" },
                new RecetaStoredModel { Id = receta2Id, Nombre = "Receta 2" }
            );

            // Seed data for RecetaIngrediente
            modelBuilder.Entity<RecetaIngredienteStoredModel>().HasData(
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = receta1Id, IdIngrediente = Guid.Parse("74998d4d-4271-46df-a900-e3c8bcb9020a"), Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = receta1Id, IdIngrediente = Guid.Parse("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), Detalle = "", Cantidad = 2 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = receta2Id, IdIngrediente = Guid.Parse("74998d4d-4271-46df-a900-e3c8bcb9020a"), Detalle = "", Cantidad = 1 },
                new RecetaIngredienteStoredModel { Id = Guid.NewGuid(), IdReceta = receta2Id, IdIngrediente = Guid.Parse("c4ea1fa6-d21a-46b7-b1a0-cf9f2934ec50"), Detalle = "", Cantidad = 2 }
            );

            // Seed data for RecetaInstruccion
            modelBuilder.Entity<RecetaInstruccionStoredModel>().HasData(
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = receta1Id, Instruccion = "Instruccion 1" },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = receta1Id, Instruccion = "Instruccion 2" },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = receta1Id, Instruccion = "Instruccion 3" },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = receta2Id, Instruccion = "Instruccion 1" },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = receta2Id, Instruccion = "Instruccion 2" },
                new RecetaInstruccionStoredModel { Id = Guid.NewGuid(), IdReceta = receta2Id, Instruccion = "Instruccion 3" }
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
