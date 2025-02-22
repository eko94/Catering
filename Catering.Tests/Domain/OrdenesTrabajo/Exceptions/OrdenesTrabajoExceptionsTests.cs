using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.OrdenesTrabajo.Exceptions;

namespace Catering.Tests.Domain.OrdenesTrabajo
{
    public class OrdenesTrabajoExceptionsTests
    {        
        [Fact]
        public void OrdenTrabajoCreationException()
        {
            // Arrange
            string reason = "El cocinero no puede ser nulo";

            // Act
            OrdenTrabajoCreationException exec = new OrdenTrabajoCreationException(reason);

            // Assert
            Assert.EndsWith(reason, exec.Message);
        }
    }
}
