using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
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
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<OrdenTrabajo> OrdenTrabajo { get; set; }
        public DbSet<OrdenTrabajoCliente> OrdenTrabajoCliente { get; set; }
        public DbSet<Receta> Receta { get; set; }
        public DbSet<RecetaIngrediente> RecetaIngrediente { get; set; }
        public DbSet<RecetaInstruccion> RecetaInstruccion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DomainDbContext(DbContextOptions<DomainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
