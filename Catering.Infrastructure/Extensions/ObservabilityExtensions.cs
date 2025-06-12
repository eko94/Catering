using Catering.Application.Abstraction;
using Catering.Infrastructure.Observability;
using Joseco.CommunicationExternal.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Extensions
{
    public static class ObservabilityExtensions
    {
        public static IServiceCollection AddObservability(this IServiceCollection services)//, IHostEnvironment environment)
        {
            services.AddScoped<ICorrelationIdProvider, CorrelationIdProvider>();

            //if (environment is IWebHostEnvironment)
            //{
            //    services.AddServicesHealthChecks();
            //}
            return services;
        }

        private static IServiceCollection AddServicesHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services
                .AddHealthChecks()
                //.AddNpgSql(connectionString)
                .AddRabbitMqHealthCheck();

            return services;
        }
    }
}
