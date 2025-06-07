using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.Contratos;
using Catering.Domain.Ingredientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.DomainModel
{
    public class DomainDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Comida> Comida { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<ContratoEntregaCancelada> ContratoEntregaCancelada { get; set; }
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<OrdenTrabajo> OrdenTrabajo { get; set; }
        public DbSet<OrdenTrabajoCliente> OrdenTrabajoCliente { get; set; }
        public DbSet<PlanAlimentario> PlanAlimentario { get; set; }
        public DbSet<PlanAlimentarioReceta> PlanAlimentarioReceta { get; set; }
        public DbSet<Receta> Receta { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngrediente { get; set; }
        public DbSet<RecetaInstruccion> RecetaInstruccion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<OutboxMessage<DomainEvent>> OutboxMessages { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly);
            modelBuilder.AddOutboxModel<DomainEvent>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
