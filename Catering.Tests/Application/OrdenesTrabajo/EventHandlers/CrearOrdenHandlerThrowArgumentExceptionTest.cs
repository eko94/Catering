using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class CrearOrdenHandlerThrowArgumentExceptionTest
    {
        private readonly Mock<IOrdenTrabajoRepository> _ordenTrabajoRepository;
        private readonly Mock<IOrdenTrabajoFactory> _ordenTrabajoFactory;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CrearOrdenHandlerThrowArgumentExceptionTest()
        {
            _ordenTrabajoRepository = new Mock<IOrdenTrabajoRepository>();
            _ordenTrabajoFactory = new Mock<IOrdenTrabajoFactory>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _clienteRepository = new Mock<IClienteRepository>();
            _recetaRepository = new Mock<IRecetaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task CrearOrdenHandlerThrowArgumentExceptionUsuarioCocinero()
        {
            // Arrange
            Guid idUsuarioCocinero = Guid.NewGuid();
            Guid idReceta = Guid.NewGuid();
            Guid idCliente1 = Guid.NewGuid();
            Guid idCliente2 = Guid.NewGuid();
            List<Guid> clientes = new List<Guid>
            {
                idCliente1,
                idCliente2
            };
            int cantidad = 1;

            _usuarioRepository.Setup(x => x.GetByIdAsync(idUsuarioCocinero, false))
                .ReturnsAsync((Usuario?) null); // Simulando que el usuario no existe

            CrearOrdenHandler asd = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _recetaRepository.Object, _unitOfWork.Object);
            
            var tcs = new CancellationTokenSource(1000);

            //Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => asd.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, clientes), tcs.Token));

            // Assert
            Assert.Equal("Usuario cocinero no es válido", ex.Message);
        }

        [Fact]
        public async Task CrearOrdenHandlerThrowArgumentExceptionReceta()
        {
            // Arrange
            Guid idUsuarioCocinero = Guid.NewGuid();
            string nombreUsuarioCocinero = "Usuario Cocinero";
            Usuario usuarioCocinero = new Usuario(idUsuarioCocinero, nombreUsuarioCocinero);

            _usuarioRepository.Setup(x => x.GetByIdAsync(idUsuarioCocinero, false))
                .ReturnsAsync(usuarioCocinero);


            Guid idReceta = Guid.NewGuid();

            _recetaRepository.Setup(x => x.GetByIdAsync(idReceta, false))
                .ReturnsAsync((Receta?) null);


            Guid idCliente1 = Guid.NewGuid();
            Guid idCliente2 = Guid.NewGuid();
            List<Guid> clientes = new List<Guid>
            {
                idCliente1,
                idCliente2
            };

            int cantidad = 1;

            CrearOrdenHandler asd = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _recetaRepository.Object, _unitOfWork.Object);
            
            var tcs = new CancellationTokenSource(1000);

            //Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => asd.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, clientes), tcs.Token));

            // Assert
            Assert.Equal("Receta no es válida", ex.Message);
        }

        [Fact]
        public async Task CrearOrdenHandlerThrowArgumentExceptionCliente()
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
                .ReturnsAsync((Cliente?) null);


            int cantidad = 1;


            CrearOrdenHandler asd = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _recetaRepository.Object, _unitOfWork.Object);
            
            var tcs = new CancellationTokenSource(1000);

            //Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => asd.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, clientes), tcs.Token));

            // Assert
            Assert.Equal("Cliente no es válido", ex.Message);
        }
    }
}
