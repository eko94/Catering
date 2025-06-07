using Catering.Application.Contratos.CrearEntregaCancelada;
using Catering.Application.PlanAlimentario.CrearPlan;
using Catering.Domain.PlanAlimentario;
using Catering.Integration.EvaluacionNutricional;
using Catering.Integration.Logistica;
using Joseco.Communication.External.RabbitMQ.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.RabbitMQ.Consumers
{
    public class EntregaCanceladaConsumer : IIntegrationMessageConsumer<EntregaCancelada>
    {
        private readonly IMediator _mediator;

        public EntregaCanceladaConsumer(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task HandleAsync(EntregaCancelada message, CancellationToken cancellationToken)
        {
            CrearEntregaCanceladaCommand command = new CrearEntregaCanceladaCommand(
                message.IdContrato,
                message.FechaCancelada);

            await _mediator.Send(command, cancellationToken);
        }
    }
}