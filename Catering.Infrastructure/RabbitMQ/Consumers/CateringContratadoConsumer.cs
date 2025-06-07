using Catering.Application.Contratos.CrearContrato;
using Catering.Application.PlanAlimentario.CrearPlan;
using Catering.Domain.PlanAlimentario;
using Catering.Integration.Comercial;
using Joseco.Communication.External.RabbitMQ.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.RabbitMQ.Consumers
{
    public class CateringContratadoConsumer : IIntegrationMessageConsumer<CateringContratado>
    {
        private readonly IMediator _mediator;

        public CateringContratadoConsumer(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task HandleAsync(CateringContratado message, CancellationToken cancellationToken)
        {
            CrearContratoCommand command = new CrearContratoCommand(
                message.IdContrato,
                message.IdCliente,
                message.IdPlanAlimentario);

            await _mediator.Send(command, cancellationToken);
        }
    }
}