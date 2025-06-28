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

namespace Catering.Tests.Domain.Clientes
{
    public class ClienteFactoryTest
    {
        private Guid _idCliente = Guid.NewGuid();
        private string _nombre = "Cliente Test";

        [Fact]
        public void CreacionClienteEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new ClienteFactory().CreateCliente(_idCliente, _nombre);

            // Assert
            Assert.Equal(_idCliente, ordenTrabajo.Id);
            Assert.Equal(_nombre, ordenTrabajo.Nombre);            
        }

        [Fact]
        public void CreacionClienteEsInvalidoId()
        {
            // Arrange

            // Act
            Action act = () => new ClienteFactory().CreateCliente(Guid.Empty, _nombre);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }        

        [Fact]
        public void CreacionClienteEsInvalidoNombre()
        {
            // Arrange

            // Act
            Action act = () => new ClienteFactory().CreateCliente(_idCliente, null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
