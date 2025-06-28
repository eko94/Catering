using Azure.Core;
using Catering.Application.Contratos.CrearContrato;
using Catering.Application.Contratos.CrearEntregaCancelada;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Catering.Infrastructure.Repositories;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.Contratos.EventHandlers
{
    public class CrearContratoHandlerTest
    {        
        private readonly Mock<IContratoRepository> _contratoRepository;        
        private readonly Mock<IContratoFactory> _contratoFactory;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IPlanAlimentarioRepository> _planAlimentarioRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CrearContratoHandlerTest()
        {
            _contratoRepository = new Mock<IContratoRepository>();
            _contratoFactory = new Mock<IContratoFactory>();
            _clienteRepository = new Mock<IClienteRepository>();
            _planAlimentarioRepository = new Mock<IPlanAlimentarioRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task CrearContratoHandler()
        {
            // Arrange
            Guid idContrato = Guid.NewGuid();            
            Guid idCliente = Guid.NewGuid();
            Guid idPlanAlimentario = Guid.NewGuid();
            int diasContratados = 15;
            DateTime fechaInicio = DateTime.Today;
            DateTime fechaCancelada = DateTime.Today.AddDays(5);

            Contrato contrato = new Contrato(idContrato, idCliente, idPlanAlimentario, diasContratados, fechaInicio);
            Cliente cliente = new Cliente(idCliente, "Cliente 1");
            PlanAlimentario planAlimentario = new PlanAlimentario(idPlanAlimentario, "Plan 1", "Plan", diasContratados, new List<PlanAlimentarioReceta>());

            _contratoFactory.Setup(x => x.CreateContrato(idContrato, idCliente, idPlanAlimentario, diasContratados, fechaInicio))
                .Returns(contrato);

            _contratoRepository.Setup(x => x.GetByIdAsync(contrato.Id, false))
                .ReturnsAsync((Contrato?)null);
            _clienteRepository.Setup(x => x.GetByIdAsync(cliente.Id, false))
                .ReturnsAsync(cliente);
            _planAlimentarioRepository.Setup(x => x.GetByIdAsync(planAlimentario.Id, false))
                .ReturnsAsync(planAlimentario);
            _contratoRepository.Setup(x => x.AddAsync(It.IsAny<Contrato>()));
            _contratoRepository.Setup(x => x.AddEntregaCancelada(It.IsAny<ContratoEntregaCancelada>()));

            CrearContratoHandler crearContratoHandler = new CrearContratoHandler(_contratoRepository.Object, _contratoFactory.Object, 
                _clienteRepository.Object, _planAlimentarioRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await crearContratoHandler.Handle(new CrearContratoCommand(idContrato, idCliente, idPlanAlimentario), tcs.Token);

            //Assert
            _contratoRepository.Verify(x => x.AddAsync(It.IsAny<Contrato>()), Times.Once);
            _contratoFactory.Verify(x => x.CreateContrato(idContrato, idCliente, idPlanAlimentario, diasContratados, fechaInicio), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
    }
}
