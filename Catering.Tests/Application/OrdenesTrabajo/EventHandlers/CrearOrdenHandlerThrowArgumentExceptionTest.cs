﻿using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Catering.Infrastructure.Repositories;
using Moq;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class CrearOrdenHandlerThrowArgumentExceptionTest
    {
        private readonly Mock<IOrdenTrabajoRepository> _ordenTrabajoRepository;
        private readonly Mock<IOrdenTrabajoFactory> _ordenTrabajoFactory;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;
        private readonly Mock<IClienteRepository> _clienteRepository;
        private readonly Mock<IContratoRepository> _contratoRepository;
        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CrearOrdenHandlerThrowArgumentExceptionTest()
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
        public async Task CrearOrdenHandlerThrowArgumentExceptionUsuarioCocinero()
        {
            // Arrange
            Guid idUsuarioCocinero = Guid.NewGuid();
            Guid idReceta = Guid.NewGuid();
            Guid idCliente1 = Guid.NewGuid();
            Guid idCliente2 = Guid.NewGuid();
            Guid idContrato1 = Guid.NewGuid();
            Guid idContrato2 = Guid.NewGuid();

            List<CrearOrdenClienteCommand> ordenClientes = new List<CrearOrdenClienteCommand>
            {
                new CrearOrdenClienteCommand(idCliente1, idContrato1),
                new CrearOrdenClienteCommand(idCliente2, idContrato2)
            };
            int cantidad = 1;

            _usuarioRepository.Setup(x => x.GetByIdAsync(idUsuarioCocinero, false))
                .ReturnsAsync((Usuario?) null); // Simulando que el usuario no existe

            CrearOrdenHandler crearOrdenHandler = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _contratoRepository.Object, _recetaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => crearOrdenHandler.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, ordenClientes), tcs.Token));

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
            Guid idContrato1 = Guid.NewGuid();
            Guid idContrato2 = Guid.NewGuid();

            List<CrearOrdenClienteCommand> ordenClientes = new List<CrearOrdenClienteCommand>
            {
                new CrearOrdenClienteCommand(idCliente1, idContrato1),
                new CrearOrdenClienteCommand(idCliente2, idContrato2)
            };

            int cantidad = 1;

            CrearOrdenHandler crearOrdenHandler = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _contratoRepository.Object, _recetaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => crearOrdenHandler.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, ordenClientes), tcs.Token));

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

            Contrato contrato1 = new Contrato(Guid.NewGuid(), idCliente1, Guid.NewGuid(), 15, DateTime.Today.AddDays(1));
            Contrato contrato2 = new Contrato(Guid.NewGuid(), idCliente2, Guid.NewGuid(), 15, DateTime.Today.AddDays(1));

            List<CrearOrdenClienteCommand> ordenClientes = new List<CrearOrdenClienteCommand>
            {
                new CrearOrdenClienteCommand(cliente1.Id, contrato1.Id),
                new CrearOrdenClienteCommand(cliente2.Id, contrato2.Id)
            };

            _clienteRepository.Setup(x => x.GetByIdAsync(idCliente1, false))
                .ReturnsAsync(cliente1);
            _contratoRepository.Setup(x => x.GetByIdAsync(contrato1.Id, false))
                .ReturnsAsync(contrato1);
            _clienteRepository.Setup(x => x.GetByIdAsync(idCliente2, false))
                .ReturnsAsync((Cliente?) null);


            int cantidad = 1;


            CrearOrdenHandler crearOrdenHandler = new CrearOrdenHandler(_ordenTrabajoRepository.Object, _ordenTrabajoFactory.Object, _usuarioRepository.Object, _clienteRepository.Object, _contratoRepository.Object, _recetaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => crearOrdenHandler.Handle(new CrearOrdenCommand(idUsuarioCocinero, idReceta, cantidad, ordenClientes), tcs.Token));

            // Assert
            Assert.Equal("Cliente no es válido", ex.Message);
        }
    }
}
