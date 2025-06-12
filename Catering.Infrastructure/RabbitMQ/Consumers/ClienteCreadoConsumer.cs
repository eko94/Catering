using Catering.Application.Clientes.CrearCliente;
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
    public class ClienteCreadoConsumer : IIntegrationMessageConsumer<ClienteCreado>
    {
        private readonly IMediator _mediator;

        public ClienteCreadoConsumer(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task HandleAsync(ClienteCreado message, CancellationToken cancellationToken)
        {
            CrearClienteCommand command = new CrearClienteCommand(
                message.Id,
                message.Nombre);

            await _mediator.Send(command, cancellationToken);
        }
    }
}