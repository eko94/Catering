using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Application.OrdenesTrabajo.EtiquetarComidas;
using Catering.Application.OrdenesTrabajo.PrepararReceta;
using Catering.Application.Receta.EventHandlers;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.OrdenesTrabajo.Events;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class EtiquetarOrdenHandlerTest
    {
        private readonly Mock<IOrdenTrabajoRepository> _ordenTrabajoRepository;
        private readonly Mock<IOrdenTrabajoFactory> _ordenTrabajoFactory;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IComidaRepository> _comidaRepository;
        private readonly Mock<IComidaFactory> _comidaFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public EtiquetarOrdenHandlerTest()
        {
            _ordenTrabajoRepository = new Mock<IOrdenTrabajoRepository>();
            _ordenTrabajoFactory = new Mock<IOrdenTrabajoFactory>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _clienteRepository = new Mock<IClienteRepository>();
            _recetaRepository = new Mock<IRecetaRepository>();
            _comidaRepository = new Mock<IComidaRepository>();
            _comidaFactory = new Mock<IComidaFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task EtiquetarOrdenHandler()
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
            List<Guid> clientes = new List<Guid>
            {
                cliente1.Id,
                cliente2.Id
            };

            _clienteRepository.Setup(x => x.GetByIdAsync(idCliente1, false))
                .ReturnsAsync(cliente1);
            _clienteRepository.Setup(x => x.GetByIdAsync(idCliente2, false))
                .ReturnsAsync(cliente2);


            int cantidad = 1;
            OrdenTrabajo ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), idUsuarioCocinero, idReceta, cantidad, OrdenTrabajoType.Comida, clientes);

            _ordenTrabajoFactory.Setup(x => x.CreateOrdenTrabajo(idUsuarioCocinero, idReceta, cantidad, clientes))
                .Returns(ordenTrabajo);
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


            CrearOrdenHandler crearOrdenHandler = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _recetaRepository.Object, _unitOfWork.Object);
            PrepararRecetaHandler prepararRecetaHandler = new PrepararRecetaHandler(_ordenTrabajoRepository.Object, _recetaRepository.Object, _unitOfWork.Object);
            PrepararRecetaCuandoOrdenTrabajoEnPreparacionHandler prepararRecetaCuandoOrdenTrabajoEnPreparacionHandler = new PrepararRecetaCuandoOrdenTrabajoEnPreparacionHandler(_recetaRepository.Object, _ordenTrabajoRepository.Object, _unitOfWork.Object, _comidaRepository.Object, _comidaFactory.Object);
            EmpaquetarComidasHandler empaquetarOrdenHandler = new EmpaquetarComidasHandler(_ordenTrabajoRepository.Object, _unitOfWork.Object);
            EtiquetarComidasHandler etiquetarComidasHandler = new EtiquetarComidasHandler(_ordenTrabajoRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await crearOrdenHandler.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, clientes), tcs.Token);
            await prepararRecetaHandler.Handle(new PrepararRecetaCommand(ordenTrabajo.Id), tcs.Token);
            await prepararRecetaCuandoOrdenTrabajoEnPreparacionHandler.Handle(new OrdenTrabajoEnPreparacionEvent(ordenTrabajo.Id, ordenTrabajo.IdReceta, ordenTrabajo.Cantidad), tcs.Token);
            await empaquetarOrdenHandler.Handle(new EmpaquetarComidasCommand(ordenTrabajo.Id), tcs.Token);
            await etiquetarComidasHandler.Handle(new EtiquetarComidasCommand(ordenTrabajo.Id), tcs.Token);

            //Assert
            _usuarioRepository.Verify(x => x.GetByIdAsync(idUsuarioCocinero, false), Times.Once);
            _recetaRepository.Verify(x => x.GetByIdAsync(idReceta, false), Times.Exactly(2));
            _clienteRepository.Verify(x => x.GetByIdAsync(idCliente1, false), Times.Once);
            _comidaRepository.Verify(x => x.AddAsync(comidaPorPreparar), Times.Once);
            _ordenTrabajoFactory.Verify(x => x.CreateOrdenTrabajo(idUsuarioCocinero, idReceta, cantidad, clientes), Times.Once);
            _ordenTrabajoRepository.Verify(x => x.AddAsync(ordenTrabajo), Times.Once);
            _ordenTrabajoRepository.Verify(x => x.GetByIdAsync(ordenTrabajo.Id, false), Times.Exactly(4));
            _ordenTrabajoRepository.Verify(x => x.UpdateAsync(ordenTrabajo), Times.Exactly(4));

            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Exactly(5));
        }
    }
}
