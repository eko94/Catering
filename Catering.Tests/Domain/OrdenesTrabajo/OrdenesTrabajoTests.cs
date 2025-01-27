using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;

namespace Catering.Tests.Domain.OrdenesTrabajo
{
    public class OrdenesTrabajoTests
    {
        private Guid _idUsuarioCocinero = Guid.NewGuid();
        private Guid _idReceta = Guid.NewGuid();
        private int _cantidad = 1;
        private OrdenTrabajoType _tipo = OrdenTrabajoType.Comida;
        private List<Guid> _clientes = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid()
        };

        [Fact]
        public void CreacionOrdenTrabajoEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new OrdenTrabajo(_idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);

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
            var ordenTrabajo = new OrdenTrabajo(_idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
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

        //[Fact]
        public void EmpaquetarComidasOrdenTrabajoEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new OrdenTrabajo(_idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.PrepararReceta();//TODO: DomainEvent?
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

        //[Fact]
        public void EtiquetarComidasOrdenTrabajoEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new OrdenTrabajo(_idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
            ordenTrabajo.PrepararReceta();
            ordenTrabajo.EmpaquetarComidas();//TODO: DomainEvent?
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
        public void CancelarOrdenTrabajoEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new OrdenTrabajo(_idUsuarioCocinero, _idReceta, _cantidad, _tipo, _clientes);
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
    }
}
