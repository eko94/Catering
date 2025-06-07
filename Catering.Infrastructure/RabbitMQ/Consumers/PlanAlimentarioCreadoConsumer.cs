using Catering.Application.PlanAlimentario.CrearPlan;
using Catering.Domain.PlanAlimentario;
using Catering.Integration.EvaluacionNutricional;
using Joseco.Communication.External.RabbitMQ.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.RabbitMQ.Consumers
{
    public class PlanAlimentarioCreadoConsumer : IIntegrationMessageConsumer<PlanAlimentarioCreado>
    {
        private readonly IMediator _mediator;

        public PlanAlimentarioCreadoConsumer(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task HandleAsync(PlanAlimentarioCreado message, CancellationToken cancellationToken)
        {
            CrearPlanCommand command = new CrearPlanCommand(
                message.IdPlanAlimentario,
                message.Nombre,
                message.Tipo,
                message.CantidadDias);

            await _mediator.Send(command, cancellationToken);
        }
    }
}