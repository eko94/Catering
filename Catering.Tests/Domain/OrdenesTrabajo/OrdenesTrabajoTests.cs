using Catering.Application.Receta.EventHandlers;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.OrdenesTrabajo.Events;
using Catering.Domain.Recetas;
using Catering.Infrastructure.Repositories;
using Moq;
using System.Threading;

namespace Catering.Tests.Domain.OrdenesTrabajo
{
    public class OrdenesTrabajoTests
    {
        private Guid _idOrdenTrabajo = Guid.NewGuid();
        private Guid _idUsuarioCocinero = Guid.NewGuid();
        private Guid _idReceta = Guid.NewGuid();
        private int _cantidad = 1;
        private OrdenTrabajoType _tipo = OrdenTrabajoType.Comida;
        private List<Guid> _clientes = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid()
        };

        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IOrdenTrabajoRepository> _ordenTrabajoRepository;
        private readonly Mock<IComidaRepository> _comidaRepository;
        private readonly Mock<IComidaFactory> _comidaFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public OrdenesTrabajoTests()
        {
            _recetaRepository = new Mock<IRecetaRepository>();
            _ordenTrabajoRepository = new Mock<IOrdenTrabajoRepository>();
            _comidaRepository = new Mock<IComidaRepository>();
            _comidaFactory = new Mock<IComidaFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void CreacionOrdenTrabajoEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), _idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);

            // Assert
            Assert.Equal(_idUsuarioCocinero, ordenTrabajo.IdUsuarioCocinero);
            Assert.Equal(_idReceta, ordenTrabajo.IdReceta);
            Assert.Equal(_cantidad, (int)ordenTrabajo.Cantidad);
            Assert.Equal(OrdenTrabajoStatus.Creado, ordenTrabajo.Estado);
            Assert.Equal(_tipo, ordenTrabajo.Tipo);
            Assert.Empty(ordenTrabajo.Comidas);
            Assert.Equal(_clientes, ordenTrabajo.Clientes.Select(x => x.IdCliente).ToList());
        }

        [Fact]
        public void PrepararRecetaOrdenTrabajoEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), _idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.PrepararReceta();

            // Assert
            Assert.Equal(_idUsuarioCocinero, ordenTrabajo.IdUsuarioCocinero);
            Assert.Equal(_idReceta, ordenTrabajo.IdReceta);
            Assert.Equal(_cantidad, (int)ordenTrabajo.Cantidad);
            Assert.Equal(OrdenTrabajoStatus.EnPreparacion, ordenTrabajo.Estado);
            Assert.Equal(_tipo, ordenTrabajo.Tipo);
            Assert.Empty(ordenTrabajo.Comidas);
            Assert.Equal(_clientes, ordenTrabajo.Clientes.Select(x => x.IdCliente).ToList());
        }

        [Fact]
        public void EmpaquetarComidasOrdenTrabajoEsValido()
        {
            // Arrange
            string nombreReceta = "Receta 1";
            Guid idComida = Guid.NewGuid();
            var recetaIngrediente = new List<RecetaIngrediente> { new RecetaIngrediente(_idReceta, Guid.NewGuid(), "", 1) };
            var comida = new Comida(idComida, nombreReceta, _idOrdenTrabajo);

            // Act
            var ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), _idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.PrepararReceta();
            comida.Preparar(recetaIngrediente);
            ordenTrabajo.SetComidasPreparadas(new List<Comida> { comida });
            ordenTrabajo.EmpaquetarComidas();

            // Assert
            Assert.Equal(_idUsuarioCocinero, ordenTrabajo.IdUsuarioCocinero);
            Assert.Equal(_idReceta, ordenTrabajo.IdReceta);
            Assert.Equal(_cantidad, (int)ordenTrabajo.Cantidad);
            Assert.Equal(OrdenTrabajoStatus.Empaquetado, ordenTrabajo.Estado);
            Assert.Equal(_tipo, ordenTrabajo.Tipo);
            Assert.Equal(_cantidad, ordenTrabajo.Comidas.Count);
            Assert.Equal(_clientes, ordenTrabajo.Clientes.Select(x => x.IdCliente).ToList());
        }

        [Fact]
        public void EtiquetarComidasOrdenTrabajoEsValido()
        {
            // Arrange
            string nombreReceta = "Receta 1";
            Guid idComida = Guid.NewGuid();
            var recetaIngrediente = new List<RecetaIngrediente> { new RecetaIngrediente(_idReceta, Guid.NewGuid(), "", 1) };
            var comida = new Comida(idComida, nombreReceta, _idOrdenTrabajo);

            // Act
            var ordenTrabajo = new OrdenTrabajo(_idOrdenTrabajo, _idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.PrepararReceta();            
            comida.Preparar(recetaIngrediente);
            ordenTrabajo.SetComidasPreparadas(new List<Comida> { comida });
            ordenTrabajo.EmpaquetarComidas();
            ordenTrabajo.EtiquetarComidas();

            // Assert
            Assert.Equal(_idUsuarioCocinero, ordenTrabajo.IdUsuarioCocinero);
            Assert.Equal(_idReceta, ordenTrabajo.IdReceta);
            Assert.Equal(_cantidad, (int)ordenTrabajo.Cantidad);
            Assert.Equal(OrdenTrabajoStatus.Finalizado, ordenTrabajo.Estado);
            Assert.Equal(_tipo, ordenTrabajo.Tipo);
            Assert.Equal(_cantidad, ordenTrabajo.Comidas.Count);
            Assert.Equal(_clientes, ordenTrabajo.Clientes.Select(x => x.IdCliente).ToList());
        }

        [Fact]
        public void EtiquetarComidasOrdenTrabajoEsInvalido()
        {
            // Arrange
            
            // Act
            var ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), _idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.PrepararReceta();
            Action act = () => ordenTrabajo.EtiquetarComidas();

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void EmpaquetarComidasOrdenTrabajoEsInvalido()
        {
            // Arrange
            
            // Act
            var ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), _idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.PrepararReceta();
            Action act = () => ordenTrabajo.EmpaquetarComidas();

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void CancelarOrdenTrabajoEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), _idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.CancelarOrden();

            // Assert
            Assert.Equal(_idUsuarioCocinero, ordenTrabajo.IdUsuarioCocinero);
            Assert.Equal(_idReceta, ordenTrabajo.IdReceta);
            Assert.Equal(_cantidad, (int)ordenTrabajo.Cantidad);
            Assert.Equal(OrdenTrabajoStatus.Cancelado, ordenTrabajo.Estado);
            Assert.Equal(_tipo, ordenTrabajo.Tipo);
            Assert.Empty(ordenTrabajo.Comidas);
            Assert.Equal(_clientes, ordenTrabajo.Clientes.Select(x => x.IdCliente).ToList());
        }

        [Fact]
        public void CancelarOrdenTrabajoEsInvalido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new OrdenTrabajo(Guid.NewGuid(), _idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.PrepararReceta();
            Action act = () => ordenTrabajo.CancelarOrden();

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
