using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Catering.Application.Abstraction;
using Catering.Application.OrdenesTrabajo.DomainEventHandlers;
using Catering.Domain.Abstractions;
using Catering.Domain.OrdenesTrabajo.Events;
using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.Contracts.Service;
using Moq;
using Xunit;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class SaveInOutboxWhenOrdenTrabajoFinalizadoTest
    {
        private Mock<IOutboxService<DomainEvent>> _outboxService;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<ICorrelationIdProvider> _correlationIdProvider;

        public SaveInOutboxWhenOrdenTrabajoFinalizadoTest()
        {
            _outboxService = new Mock<IOutboxService<DomainEvent>>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _correlationIdProvider = new Mock<ICorrelationIdProvider>();
        }

        [Fact]
        public async Task Handle_ShouldAddOutboxMessageAndCommit()
        {
            // Arrange
            var correlationId = Guid.NewGuid().ToString();

            _correlationIdProvider.Setup(x => x.GetCorrelationId()).Returns(correlationId);

            var handler = new SaveInOutboxWhenOrdenTrabajoFinalizado(
                _outboxService.Object,
                _unitOfWork.Object,
                _correlationIdProvider.Object
            );

            var notification = new OrdenTrabajoFinalizado(
                Guid.NewGuid(),
                new List<OrdenTrabajoFinalizadoComida>()
            );

            var cancellationToken = CancellationToken.None;

            // Act
            await handler.Handle(notification, cancellationToken);

            // Assert
            _outboxService.Verify(x => x.AddAsync(It.Is<OutboxMessage<DomainEvent>>(m => m.Content == notification)), Times.Once);

            _unitOfWork.Verify(x => x.CommitAsync(cancellationToken), Times.Once);
        }
    }
}
