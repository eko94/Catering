using Catering.Application.Contratos.GetContratosRealizarDelDia;
using Catering.Application.OrdenesTrabajo.CancelarOrden;
using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Application.OrdenesTrabajo.GetOrdenesTrabajo;
using Catering.Application.OrdenesTrabajo.GetOrdenTrabajoById;
using Catering.Application.Usuarios.GetUsuarios;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.Usuarios.EventHandlers
{
    public class GetUsuariosTest
    {
        [Fact]
        public void GetUsuariosCreacionEsValido()
        {
            // Arrange
            GetUsuariosDto dto = new GetUsuariosDto();
            Guid id = Guid.NewGuid();
            string nombre = "Nombre";

            //Act            
            dto.Id = id;
            dto.Nombre = nombre;

            //Assert
            Assert.Equal(id, dto.Id);
            Assert.Equal(nombre, dto.Nombre);
        }

        [Fact]
        public void GetUsuariosQueryEsValido()
        {
            // Arrange

            //Act
            GetContratosRealizarDelDiaQuery query = new GetContratosRealizarDelDiaQuery();

            //Assert
            Assert.NotNull(query);
        }
    }
}
