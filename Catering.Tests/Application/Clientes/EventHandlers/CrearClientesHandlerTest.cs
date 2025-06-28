using Catering.Application.Clientes.CrearCliente;
using Catering.Application.Contratos.CrearCliente;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.Clientes.EventHandlers
{
    public class CrearClientesHandlerTest
    {        
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IClienteFactory> _clienteFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CrearClientesHandlerTest()
        {
            _clienteRepository = new Mock<IClienteRepository>();
            _clienteFactory = new Mock<IClienteFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task CrearClienteHandler()
        {
            // Arrange
            Guid idCliente = Guid.NewGuid();            
            string nombreCliente = "Cliente 1";
            Guid idOrdenTrabajo = Guid.NewGuid();

            _clienteFactory.Setup(x => x.CreateCliente(idCliente, nombreCliente))
                .Returns(new Cliente(idCliente, nombreCliente));

            _clienteRepository.Setup(x => x.AddAsync(It.IsAny<Cliente>()));
                        
            CrearClienteHandler crearClienteHandler = new CrearClienteHandler(_clienteRepository.Object, _clienteFactory.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await crearClienteHandler.Handle(new CrearClienteCommand(idCliente, nombreCliente), tcs.Token);

            //Assert
            _clienteRepository.Verify(x => x.AddAsync(It.IsAny<Cliente>()), Times.Once);            
            _clienteFactory.Verify(x => x.CreateCliente(idCliente, nombreCliente), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
    }
}
