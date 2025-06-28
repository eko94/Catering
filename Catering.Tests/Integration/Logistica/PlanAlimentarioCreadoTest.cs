using Catering.Domain.Comidas;
using Catering.Integration.Catering;
using Catering.Integration.EvaluacionNutricional;
using Catering.Integration.Logistica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Integration.Logistica
{
    public class EntregaCanceladaTest
    {
        [Fact]
        public void CreacionEntregaCanceladaEsValida()
        {
            // Arrange            
            Guid id = Guid.NewGuid();
            Guid idCliente = Guid.NewGuid();
            Guid idContrato = Guid.NewGuid();
            DateTime fechaCancelada = DateTime.Now;

            // Act
            var orden = new EntregaCancelada(idCliente, idContrato, fechaCancelada);

            // Assert
            Assert.Equal(idCliente, orden.IdCliente);
            Assert.Equal(idContrato, orden.IdContrato);
            Assert.Equal(fechaCancelada, orden.FechaCancelada);
        }
    }
}
