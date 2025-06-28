using Catering.Domain.Comidas;
using Catering.Integration.Catering;
using Catering.Integration.Comercial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Integration.Comercial
{
    public class CateringContratadoTest
    {
        [Fact]
        public void CreacionCateringContratadoEsValido()
        {
            // Arrange            
            Guid idContrato = Guid.NewGuid();
            Guid idCliente = Guid.NewGuid();
            Guid idPlanAlimentario = Guid.NewGuid();

            // Act
            var orden = new CateringContratado(idContrato, idCliente, idPlanAlimentario);

            // Assert
            Assert.Equal(idContrato, orden.IdContrato);
            Assert.Equal(idCliente, orden.IdCliente);
            Assert.Equal(idPlanAlimentario, orden.IdPlanAlimentario);
        }
    }
}
