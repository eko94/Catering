using Catering.Domain.Abstractions;
using Catering.Domain.OrdenesTrabajo.Events;
using Joseco.Communication.External.Contracts.Services;
using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.Contracts.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.OutboxMessageHandlers
{
    public class PublishOrdenTrabajoFinalizado : INotificationHandler<OutboxMessage<OrdenTrabajoFinalizado>>
    {
        private readonly IExternalPublisher _integrationBusService;
        public PublishOrdenTrabajoFinalizado(IExternalPublisher integrationBusService) {
            _integrationBusService = integrationBusService;
        }

        public async Task Handle(OutboxMessage<OrdenTrabajoFinalizado> notification, CancellationToken cancellationToken) {
            List<Integration.Catering.OrdenTrabajoFinalizadoComida> comidas = notification.Content.Comidas.
                Select(x => new Integration.Catering.OrdenTrabajoFinalizadoComida(x.IdComida, x.Nombre, x.IdCliente)).ToList();

            Integration.Catering.OrdenTrabajoFinalizado message =
                new Integration.Catering.OrdenTrabajoFinalizado(notification.Id, comidas);

            await _integrationBusService.PublishAsync(message, "orden-trabajo-finalizado");
        }
    }
}