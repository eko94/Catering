using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Application.OrdenesTrabajo.EtiquetarComidas;
using Catering.Application.OrdenesTrabajo.PrepararReceta;
using Catering.Application.Receta.EventHandlers;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.OrdenesTrabajo.Events;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class PrepararOrdenHandlerTest
    {
        private readonly Mock<IOrdenTrabajoRepository> _ordenTrabajoRepository;
        private readonly Mock<IOrdenTrabajoFactory> _ordenTrabajoFactory;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IContratoRepository> _contratoRepository;
        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IComidaRepository> _comidaRepository;
        private readonly Mock<IComidaFactory> _comidaFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public PrepararOrdenHandlerTest()
        {
            _ordenTrabajoRepository = new Mock<IOrdenTrabajoRepository>();
            _ordenTrabajoFactory = new Mock<IOrdenTrabajoFactory>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _clienteRepository = new Mock<IClienteRepository>();
            _contratoRepository = new Mock<IContratoRepository>();
            _recetaRepository = new Mock<IRecetaRepository>();
            _comidaRepository = new Mock<IComidaRepository>();
            _comidaFactory = new Mock<IComidaFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task PrepararOrdenHandler()
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


            Guid idComida = Guid.NewGuid();
            Comida comidaPorPreparar = new Comida(idComida, nombreReceta, ordenTrabajo.Id);

            _comidaFactory.Setup(x => x.CreateComida(nombreReceta, ordenTrabajo.Id))
                .Returns(comidaPorPreparar);


            Comida comidaPreparada = new Comida(idComida, nombreReceta, ordenTrabajo.Id);
            comidaPreparada.Preparar(receta.Ingredientes.ToList());

            _comidaRepository.Setup(x => x.AddAsync(comidaPreparada));


            CrearOrdenHandler crearOrdenHandler = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _contratoRepository.Object, _recetaRepository.Object, _unitOfWork.Object);
            PrepararRecetaHandler prepararRecetaHandler = new PrepararRecetaHandler(_ordenTrabajoRepository.Object, _recetaRepository.Object, _unitOfWork.Object);
            PrepararRecetaCuandoOrdenTrabajoEnPreparacionHandler prepararRecetaCuandoOrdenTrabajoEnPreparacionHandler = new PrepararRecetaCuandoOrdenTrabajoEnPreparacionHandler(_recetaRepository.Object, _ordenTrabajoRepository.Object, _unitOfWork.Object, _comidaRepository.Object, _comidaFactory.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await crearOrdenHandler.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, ordenClientes), tcs.Token);
            await prepararRecetaHandler.Handle(new PrepararRecetaCommand(ordenTrabajo.Id), tcs.Token);
            await prepararRecetaCuandoOrdenTrabajoEnPreparacionHandler.Handle(new OrdenTrabajoEnPreparacionEvent(ordenTrabajo.Id, ordenTrabajo.IdReceta, ordenTrabajo.Cantidad), tcs.Token);

            //Assert
            _usuarioRepository.Verify(x => x.GetByIdAsync(idUsuarioCocinero, false), Times.Once);
            _recetaRepository.Verify(x => x.GetByIdAsync(idReceta, false), Times.Exactly(2));
            _clienteRepository.Verify(x => x.GetByIdAsync(idCliente1, false), Times.Once);
            _comidaRepository.Verify(x => x.AddAsync(comidaPorPreparar), Times.Once);
            _ordenTrabajoFactory.Verify(x => x.CreateOrdenTrabajo(idUsuarioCocinero, idReceta, cantidad, clientes), Times.Once);
            _ordenTrabajoRepository.Verify(x => x.AddAsync(ordenTrabajo), Times.Once);
            _ordenTrabajoRepository.Verify(x => x.GetByIdAsync(ordenTrabajo.Id, false), Times.Exactly(2));
            _ordenTrabajoRepository.Verify(x => x.UpdateAsync(ordenTrabajo), Times.Exactly(2));

            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Exactly(3));
        }
    }
}
