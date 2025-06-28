using Catering.Domain.Comidas;
using Catering.Integration.Catering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Integration.Catering
{
    public class OrdenTrabajoFinalizadoTest
    {
        [Fact]
        public void CreacionOrdenTrabajoFinalizadoEsValido()
        {
            // Arrange            
            Guid idOrdenTrabajo = Guid.NewGuid();
            List<OrdenTrabajoFinalizadoComida> comidas = new List<OrdenTrabajoFinalizadoComida>
            {
                new OrdenTrabajoFinalizadoComida(Guid.NewGuid(), "Pizza", Guid.NewGuid()),
            };

            // Act
            var orden = new OrdenTrabajoFinalizado(idOrdenTrabajo, comidas);

            // Assert
            Assert.Equal(idOrdenTrabajo, orden.IdOrdenTrabajo);
            Assert.Equal(comidas.Count, orden.Comidas.Count);
            Assert.Equal(comidas.ElementAt(0).IdComida, orden.Comidas.First().IdComida);
            Assert.Equal(comidas.ElementAt(0).Nombre, orden.Comidas.First().Nombre);
            Assert.Equal(comidas.ElementAt(0).IdCliente, orden.Comidas.First().IdCliente);
        }
    }
}
