using Catering.Application.Abstraction;
using Catering.Application.OrdenesTrabajo.OutboxMessageHandlers;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.OrdenesTrabajo.Events;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Catering.Infrastructure.Repositories;
using Joseco.Communication.External.Contracts.Services;
using Joseco.Outbox.Contracts.Model;
using Joseco.Outbox.Contracts.Service;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class PublishOrdenTrabajoFinalizadoTest
    {


        public PublishOrdenTrabajoFinalizadoTest()
        {
        }

        [Fact]
        public async Task PublishOrdenTrabajoFinalizado()
        {
            // Arrange
            var publisher = new Mock<IExternalPublisher>();
            var handler = new PublishOrdenTrabajoFinalizado(publisher.Object);

            var comida1 = new OrdenTrabajoFinalizadoComida(Guid.NewGuid(), "Pizza", Guid.NewGuid());
            var comida2 = new OrdenTrabajoFinalizadoComida(Guid.NewGuid(), "Pasta", Guid.NewGuid());
            var comidas = new List<OrdenTrabajoFinalizadoComida> { comida1, comida2 };

            Guid idOrdenTrabajo = Guid.NewGuid();
            var domainEvent = new OrdenTrabajoFinalizado(idOrdenTrabajo, comidas);
            var outboxMessage = new OutboxMessage<OrdenTrabajoFinalizado>(domainEvent);
                        

            // Act
            publisher.Setup(x =>
                x.PublishAsync(
                    It.IsAny<Catering.Integration.Catering.OrdenTrabajoFinalizado>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .Returns(Task.CompletedTask);

            var tcs = new CancellationTokenSource(1000);

            await handler.Handle(outboxMessage, tcs.Token);

            // Assert
            publisher.Verify(x =>
                x.PublishAsync(
                    It.Is<Catering.Integration.Catering.OrdenTrabajoFinalizado>(msg =>
                        msg.IdOrdenTrabajo == idOrdenTrabajo &&
                        msg.Comidas.Count == 2 &&
                        msg.Comidas.ElementAt(0).IdComida == comida1.IdComida &&
                        msg.Comidas.ElementAt(0).Nombre == comida1.Nombre &&
                        msg.Comidas.ElementAt(0).IdCliente == comida1.IdCliente &&
                        msg.Comidas.ElementAt(1).IdComida == comida2.IdComida &&
                        msg.Comidas.ElementAt(1).Nombre == comida2.Nombre &&
                        msg.Comidas.ElementAt(1).IdCliente == comida2.IdCliente
                    ),
                    "orden-trabajo-finalizado",
                    false
                ),
                Times.Once
            );
        }
    }
}
