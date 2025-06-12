using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services) {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddSingleton<IComidaFactory, ComidaFactory>();
            services.AddSingleton<IClienteFactory, ClienteFactory>();
            services.AddSingleton<IContratoFactory, ContratoFactory>();
            services.AddSingleton<IOrdenTrabajoFactory, OrdenTrabajoFactory>();
            services.AddSingleton<IPlanAlimentarioFactory, PlanAlimentarioFactory>();

            return services;
        }

    }
}