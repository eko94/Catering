using Catering.Application.Contratos.GetContratosRealizarDelDia;
using Catering.Application.OrdenesTrabajo.CrearOrdenesDelDia;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Usuarios;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class CrearOrdenesDelDiaHandlerTest
    {
        private readonly Mock<IOrdenTrabajoRepository> _ordenTrabajoRepository;
        private readonly Mock<IOrdenTrabajoFactory> _ordenTrabajoFactory;
        private readonly Mock<IContratoRepository> _contratoRepository;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        private readonly CrearOrdenesDelDiaHandler _handler;

        public CrearOrdenesDelDiaHandlerTest()
        {
            _ordenTrabajoRepository = new Mock<IOrdenTrabajoRepository>();
            _ordenTrabajoFactory = new Mock<IOrdenTrabajoFactory>();
            _contratoRepository = new Mock<IContratoRepository>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _clienteRepository = new Mock<IClienteRepository>();
            _mediator = new Mock<IMediator>();
            _unitOfWork = new Mock<IUnitOfWork>();

            _handler = new CrearOrdenesDelDiaHandler(
                _ordenTrabajoRepository.Object,
                _ordenTrabajoFactory.Object,
                _contratoRepository.Object,
                _usuarioRepository.Object,
                _clienteRepository.Object,
                _mediator.Object,
                _unitOfWork.Object
            );
        }

        [Fact]
        public async Task CrearOrdenesAndUpdateContratos_CuandoContratoExiste()
        {
            // Arrange
            var contratos = new List<GetContratosRealizarDelDiaDto>
            {
                new GetContratosRealizarDelDiaDto { IdContrato = Guid.NewGuid(), IdCliente = Guid.NewGuid(), IdReceta = Guid.NewGuid() },
                new GetContratosRealizarDelDiaDto { IdContrato = Guid.NewGuid(), IdCliente = Guid.NewGuid(), IdReceta = Guid.NewGuid() }
            };

            var idCocinero = Guid.NewGuid();
            var ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), idCocinero, contratos[0].IdReceta, 1, OrdenTrabajoType.Comida, new List<Guid> { contratos[0].IdCliente });

            _mediator.Setup(m => m.Send(It.IsAny<GetContratosRealizarDelDiaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(contratos);

            _usuarioRepository.Setup(r => r.GetRandomIdCocinero())
                .ReturnsAsync(idCocinero);

            _ordenTrabajoFactory.Setup(f => f.CreateOrdenTrabajo(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<List<Guid>>()))
                .Returns(ordenTrabajo);

            _contratoRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(new Contrato(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 10, DateTime.UtcNow));

            // Act
            await _handler.Handle(new CrearOrdenesDelDiaCommand(), CancellationToken.None);

            // Assert
            _ordenTrabajoRepository.Verify(r => r.AddRangeAsync(It.IsAny<List<OrdenTrabajo>>()), Times.Once);
            _contratoRepository.Verify(r => r.UpdateAsync(It.IsAny<Contrato>()), Times.Exactly(contratos.Count));
            _unitOfWork.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CrearOrdenesAndUpdateContratos_CuandoNoHayContratos()
        {
            // Arrange
            _mediator.Setup(m => m.Send(It.IsAny<GetContratosRealizarDelDiaQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<GetContratosRealizarDelDiaDto>());

            // Act
            await _handler.Handle(new CrearOrdenesDelDiaCommand(), CancellationToken.None);

            // Assert
            _ordenTrabajoRepository.Verify(r => r.AddRangeAsync(It.IsAny<List<OrdenTrabajo>>()), Times.Never);
            _contratoRepository.Verify(r => r.UpdateAsync(It.IsAny<Contrato>()), Times.Never);
            _unitOfWork.Verify(u => u.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
