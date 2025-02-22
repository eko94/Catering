using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.OrdenesTrabajo.Exceptions;

namespace Catering.Tests.Domain.OrdenesTrabajo
{
    public class OrdenesTrabajoClientesTests
    {        
        private Guid _idOrdenTrabajo = Guid.NewGuid();
        private Guid _idCliente = Guid.NewGuid();

        [Fact]
        public void UpdateEsValido()
        {
            // Arrange
            OrdenTrabajoCliente reason = new OrdenTrabajoCliente(_idOrdenTrabajo, _idCliente);

            // Act
            reason.Update(_idCliente);

            // Assert
            Assert.Equal(reason.IdCliente, _idCliente);
        }

        [Fact]
        public void UpdateEsInvalido()
        {
            // Arrange
            OrdenTrabajoCliente reason = new OrdenTrabajoCliente(_idOrdenTrabajo, _idCliente);

            // Act
            Action act = () => reason.Update(Guid.Empty);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
