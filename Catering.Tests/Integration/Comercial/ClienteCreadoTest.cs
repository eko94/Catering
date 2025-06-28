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
    public class ClienteCreadoTest
    {
        [Fact]
        public void CreacionClienteCreadoEsValido()
        {
            // Arrange            
            Guid idCliente = Guid.NewGuid();
            string nombre = "Cliente de Prueba";

            // Act
            var clienteCreado = new ClienteCreado(idCliente, nombre);

            // Assert
            Assert.Equal(idCliente, clienteCreado.Id);
            Assert.Equal(nombre, clienteCreado.Nombre);
        }
    }
}
