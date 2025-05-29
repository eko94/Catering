using Catering.Application;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Catering.Infrastructure.DomainModel;
using Catering.Infrastructure.Extensions;
using Catering.Infrastructure.Repositories;
using Catering.Infrastructure.StoredModel;
using Joseco.Communication.External.RabbitMQ.Services;
using Joseco.CommunicationExternal.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Catering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                );

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context => context.UseSqlServer(connectionString))
                .AddDbContext<DomainDbContext>(context => context.UseSqlServer(connectionString));

            services.AddScoped<IClienteRepository, ClienteRepository>()
                .AddScoped<IComidaRepository, ComidaRepository>()
                .AddScoped<IIngredienteRepository, IngredienteRepository>()
                .AddScoped<IOrdenTrabajoRepository, OrdenTrabajoRepository>()
                .AddScoped<IRecetaRepository, RecetaRepository>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>();           

            services
                .AddSecrets(configuration) 
                .AddRabbitMQ();

            services.AddAplication();

            return services;
        }
    }
}
