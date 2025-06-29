using Catering.Application.OrdenesTrabajo.CancelarOrden;
using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class CancelarOrdenHandlerTest
    {
        private readonly Mock<IOrdenTrabajoRepository> _ordenTrabajoRepository;
        private readonly Mock<IOrdenTrabajoFactory> _ordenTrabajoFactory;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IContratoRepository> _contratoRepository;
        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CancelarOrdenHandlerTest()
        {
            _ordenTrabajoRepository = new Mock<IOrdenTrabajoRepository>();
            _ordenTrabajoFactory = new Mock<IOrdenTrabajoFactory>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _clienteRepository = new Mock<IClienteRepository>();
            _contratoRepository = new Mock<IContratoRepository>();
            _recetaRepository = new Mock<IRecetaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task CancelarOrdenHandler()
        {
            // Arrange
            Guid idUsuarioCocinero = Guid.NewGuid();
            string nombreUsuarioCocinero = "Usuario Cocinero";
            Usuario usuarioCocinero = new Usuario(idUsuarioCocinero, nombreUsuarioCocinero);

            _usuarioRepository.Setup(x => x.GetByIdAsync(idUsuarioCocinero, false))
                .ReturnsAsync(usuarioCocinero);


            Guid idReceta = Guid.NewGuid();
            string nombreReceta = "Receta 1";
            Receta receta = new Receta(idReceta, nombreReceta);

            _recetaRepository.Setup(x => x.GetByIdAsync(idReceta, false))
                .ReturnsAsync(receta);


            Guid idCliente1 = Guid.NewGuid();
            string nombreCliente1 = "Cliente 1";
            Cliente cliente1 = new Cliente(idCliente1, nombreCliente1);
            Guid idCliente2 = Guid.NewGuid();
            string nombreCliente2 = "Cliente 2";
            Cliente cliente2 = new Cliente(idCliente2, nombreCliente2);

            Guid idOrden = Guid.NewGuid();
            Contrato contrato1 = new Contrato(Guid.NewGuid(), idCliente1, Guid.NewGuid(), 15, DateTime.Today.AddDays(1));
            Contrato contrato2 = new Contrato(Guid.NewGuid(), idCliente2, Guid.NewGuid(), 15, DateTime.Today.AddDays(1));

            List<OrdenTrabajoCliente> clientes = new List<OrdenTrabajoCliente>
            {
                new OrdenTrabajoCliente(idOrden, cliente1.Id, contrato1.Id),
                new OrdenTrabajoCliente(idOrden, cliente2.Id, contrato2.Id)
            };
            List<CrearOrdenClienteCommand> ordenClientes = new List<CrearOrdenClienteCommand>
            {
                new CrearOrdenClienteCommand(cliente1.Id, contrato1.Id),
                new CrearOrdenClienteCommand(cliente2.Id, contrato2.Id)
            };

            _clienteRepository.Setup(x => x.GetByIdAsync(idCliente1, false))
                .ReturnsAsync(cliente1);
            _clienteRepository.Setup(x => x.GetByIdAsync(idCliente2, false))
                .ReturnsAsync(cliente2);

            _contratoRepository.Setup(x => x.GetByIdAsync(contrato1.Id, false))
                .ReturnsAsync(contrato1);
            _contratoRepository.Setup(x => x.GetByIdAsync(contrato2.Id, false))
                .ReturnsAsync(contrato2);

            int cantidad = 1;
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo(idOrden, idUsuarioCocinero, idReceta, cantidad, OrdenTrabajoType.Comida, clientes);

            _ordenTrabajoFactory.Setup(x => x.CreateOrdenTrabajo(idUsuarioCocinero, idReceta, cantidad, clientes))
                .Returns(ordenTrabajo);
            _ordenTrabajoFactory.Setup(x => x.CreateOrdenTrabajoCliente(clientes[0].IdCliente, clientes[0].IdContrato))
                .Returns(clientes[0]);
            _ordenTrabajoFactory.Setup(x => x.CreateOrdenTrabajoCliente(clientes[1].IdCliente, clientes[1].IdContrato))
                .Returns(clientes[1]);
            _ordenTrabajoRepository.Setup(x => x.AddAsync(ordenTrabajo));
            _ordenTrabajoRepository.Setup(x => x.GetByIdAsync(ordenTrabajo.Id, false))
                .ReturnsAsync(ordenTrabajo);
            _ordenTrabajoRepository.Setup(x => x.UpdateAsync(ordenTrabajo));


            CrearOrdenHandler crearOrdenHandler = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _contratoRepository.Object, _recetaRepository.Object, _unitOfWork.Object);

            CancelarOrdenHandler cancelarOrdenHandler = new CancelarOrdenHandler(_ordenTrabajoRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await crearOrdenHandler.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, ordenClientes), tcs.Token);
            await cancelarOrdenHandler.Handle(new CancelarOrdenCommand(ordenTrabajo.Id), tcs.Token);

            //Assert
            _usuarioRepository.Verify(x => x.GetByIdAsync(idUsuarioCocinero, false), Times.Once);
            _recetaRepository.Verify(x => x.GetByIdAsync(idReceta, false), Times.Once);
            _clienteRepository.Verify(x => x.GetByIdAsync(idCliente1, false), Times.Once);
            _ordenTrabajoFactory.Verify(x => x.CreateOrdenTrabajo(idUsuarioCocinero, idReceta, cantidad, clientes), Times.Once);
            _ordenTrabajoRepository.Verify(x => x.AddAsync(ordenTrabajo), Times.Once);
            _ordenTrabajoRepository.Verify(x => x.GetByIdAsync(ordenTrabajo.Id, false), Times.Once);
            _ordenTrabajoRepository.Verify(x => x.UpdateAsync(ordenTrabajo), Times.Once);

            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Exactly(2));
        }
    }
}
