using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Infrastructure.DomainModel;
using Catering.Infrastructure.StoredModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel
{
    public class StoredDbContext : DbContext
    {
        public DbSet<ClienteStoredModel> Cliente { get; set; }
        public DbSet<ComidaStoredModel> Comida { get; set; }
        public DbSet<IngredienteStoredModel> Ingrediente { get; set; }
        public DbSet<OrdenTrabajoClienteStoredModel> OrdenTrabajoCliente { get; set; }
        public DbSet<OrdenTrabajoStoredModel> OrdenTrabajo { get; set; }
        public DbSet<RecetaIngredienteStoredModel> RecetaIngrediente { get; set; }
        public DbSet<RecetaInstruccionStoredModel> RecetaInstruccion { get; set; }
        public DbSet<RecetaStoredModel> Receta { get; set; }
        public DbSet<UsuarioStoredModel> Usuario { get; set; }

        public StoredDbContext(DbContextOptions<StoredDbContext> options) : base(options)
        {
        }
    }
}
