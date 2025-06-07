using Catering.Infrastructure.RabbitMQ.Consumers;
using Catering.Integration.Comercial;
using Catering.Integration.EvaluacionNutricional;
using Catering.Integration.Logistica;
using Joseco.Communication.External.RabbitMQ.Services;
using Joseco.CommunicationExternal.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using Nur.Store2025.Integration.Catalog;
using Nur.Store2025.Integration.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Extensions
{
    public static class BrokerExtensions
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            var rabbitMqSettings = serviceProvider.GetRequiredService<RabbitMqSettings>();

            services.AddRabbitMQ(rabbitMqSettings)
                .AddRabbitMqConsumer<PlanAlimentarioCreado, PlanAlimentarioCreadoConsumer>("catering.plan-alimentario-creado")
                .AddRabbitMqConsumer<CateringContratado, CateringContratadoConsumer>("catering.catering-contratado")
                .AddRabbitMqConsumer<EntregaCancelada, EntregaCanceladaConsumer>("catering.entrega-cancelada");

            return services;
        }
    }
}
