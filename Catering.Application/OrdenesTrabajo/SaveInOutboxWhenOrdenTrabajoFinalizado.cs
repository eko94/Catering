using Catering.Domain.OrdenesTrabajo.Events;
using Joseco.Communication.External.Contracts.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo
{
    public class SaveInOutboxWhenOrdenTrabajoFinalizado : INotificationHandler<OrdenTrabajoFinalizado>
    {
        private readonly IExternalPublisher _publisher;

        public SaveInOutboxWhenOrdenTrabajoFinalizado(IExternalPublisher publisher) 
        {
            _publisher = publisher;
        }

        public async Task Handle(OrdenTrabajoFinalizado notification, CancellationToken cancellationToken) 
        {
            //TODO: IMPLEMENTAR OUTBOX
            List<Integration.Catering.OrdenTrabajoFinalizadoComida> comidas = notification.Comidas.
                Select(x => new Integration.Catering.OrdenTrabajoFinalizadoComida
                {
                    Id = x.Id,
                    IdCliente = x.IdCliente,
                    Nombre = x.Nombre,
                }).ToList();

            Integration.Catering.OrdenTrabajoFinalizado message =
                new Integration.Catering.OrdenTrabajoFinalizado(notification.Id, comidas);

            await _publisher.PublishAsync(message, "orden-trabajo-finalizado");
        }
    }
}
