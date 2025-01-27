using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Infrastructure.DomainModel;
using Catering.Infrastructure.Repositories;
using Catering.Infrastructure.StoredModel;
using Catering.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Catering.Domain.Clientes;
using Catering.Domain.Usuarios;

namespace Catering.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                );

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context => context.UseSqlServer(connectionString));
            services.AddDbContext<DomainDbContext>(context => context.UseSqlServer(connectionString));

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IComidaRepository, ComidaRepository>();
            services.AddScoped<IIngredienteRepository, IngredienteRepository>();
            services.AddScoped<IOrdenTrabajoRepository, OrdenTrabajoRepository>();
            services.AddScoped<IRecetaRepository, RecetaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAplication();

            return services;
        }
    }
}
