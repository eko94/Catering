using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.Contratos;
using Catering.Domain.Ingredientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Catering.Infrastructure.DomainModel;
using Catering.Infrastructure.Repositories;
using Catering.Infrastructure.StoredModel;
using Joseco.Outbox.EFCore;
using Joseco.Outbox.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context => context.UseSqlServer(connectionString))
                .AddDbContext<DomainDbContext>(context => context.UseSqlServer(connectionString));

            services.AddScoped<IClienteRepository, ClienteRepository>()
                .AddScoped<IComidaRepository, ComidaRepository>()
                .AddScoped<IContratoRepository, ContratoRepository>()
                .AddScoped<IIngredienteRepository, IngredienteRepository>()
                .AddScoped<IOrdenTrabajoRepository, OrdenTrabajoRepository>()
                .AddScoped<IPlanAlimentarioRepository, PlanAlimentarioRepository>()
                .AddScoped<IRecetaRepository, RecetaRepository>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()

                .AddScoped<IOutboxDatabase<DomainEvent>, UnitOfWork>()
                .AddOutbox<DomainEvent>();

            return services;
        }
    }
}
