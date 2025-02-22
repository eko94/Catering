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
    public class OrdenesTrabajoFactory
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
            var ordenTrabajo = new OrdenTrabajoFactory().CreateOrdenTrabajo(_idUsuarioCocinero, _idReceta, _cantidad, _clientes);

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
        public void CreacionOrdenTrabajoEsInvalidoIdUsuarioCocinero()
        {
            // Arrange

            // Act
            Action act = () => new OrdenTrabajoFactory().CreateOrdenTrabajo(Guid.Empty, _idReceta, _cantidad, _clientes);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }        

        [Fact]
        public void CreacionOrdenTrabajoEsInvalidoIdReceta()
        {
            // Arrange

            // Act
            Action act = () => new OrdenTrabajoFactory().CreateOrdenTrabajo(_idUsuarioCocinero, Guid.Empty, _cantidad, _clientes);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void CreacionOrdenTrabajoEsInvalidoCantidad()
        {
            // Arrange

            // Act
            Action act = () => new OrdenTrabajoFactory().CreateOrdenTrabajo(_idUsuarioCocinero, _idReceta, -1, _clientes);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CreacionOrdenTrabajoEsInvalidoClientes()
        {
            // Arrange

            // Act
            Action act = () => new OrdenTrabajoFactory().CreateOrdenTrabajo(_idUsuarioCocinero, _idReceta, _cantidad, new List<Guid>());

            // Assert
            Assert.Throws<ArgumentException>(act);
        }        
    }
}
