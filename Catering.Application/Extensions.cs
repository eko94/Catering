using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
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
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddSingleton<IComidaFactory, ComidaFactory>();
            services.AddSingleton<IOrdenTrabajoFactory, OrdenTrabajoFactory>();

            return services;
        }

    }
}
