using Catering.Application.Abstraction;
using Catering.Domain.Abstractions;
using Catering.Domain.OrdenesTrabajo.Events;
using Joseco.Communication.External.Contracts.Services;
using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.Contracts.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.DomainEventHandlers
{
    public class SaveInOutboxWhenOrdenTrabajoFinalizado : INotificationHandler<OrdenTrabajoFinalizado>
    {
        private readonly IOutboxService<DomainEvent> _outboxService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public SaveInOutboxWhenOrdenTrabajoFinalizado(IOutboxService<DomainEvent> outboxService,
            IUnitOfWork unitOfWork, ICorrelationIdProvider correlationIdProvider) {
            _outboxService = outboxService;
            _unitOfWork = unitOfWork;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task Handle(OrdenTrabajoFinalizado notification, CancellationToken cancellationToken) {
            var correlationId = _correlationIdProvider.GetCorrelationId();
            OutboxMessage<DomainEvent> outboxMessage = new(notification);
            await _outboxService.AddAsync(outboxMessage);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}