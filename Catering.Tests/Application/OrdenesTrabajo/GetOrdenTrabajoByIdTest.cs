using Catering.Application.OrdenesTrabajo.CancelarOrden;
using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Application.OrdenesTrabajo.GetOrdenesTrabajo;
using Catering.Application.OrdenesTrabajo.GetOrdenTrabajoById;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class GetOrdenTrabajoByIdTest
    {
        [Fact]
        public async Task GetOrdenTrabajoByIdDtoCreacionEsValido()
        {
            // Arrange
            GetOrdenTrabajoByIdDto dto = new GetOrdenTrabajoByIdDto();
            Guid id = Guid.NewGuid();
            string usuarioCocineroNombre = "Cocinero";
            string recetaNombre = "receta";
            int cantidad = 1;
            string estado = "Creado";
            string tipo = "Comida";

            //Act            
            dto.Id = id;
            dto.UsuarioCocineroNombre = usuarioCocineroNombre;
            dto.RecetaNombre = recetaNombre;
            dto.Cantidad = cantidad;
            dto.Estado = estado;
            dto.Tipo = tipo;

            //Assert
            Assert.Equal(id, dto.Id);
            Assert.Equal(usuarioCocineroNombre, dto.UsuarioCocineroNombre);
            Assert.Equal(recetaNombre, dto.RecetaNombre);
            Assert.Equal(cantidad, dto.Cantidad);
            Assert.Equal(estado, dto.Estado);
            Assert.Equal(tipo, dto.Tipo);
        }

        [Fact]
        public void GetOrdenesTrabajoQueryEsValido()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            //Act
            GetOrdenTrabajoByIdQuery query = new GetOrdenTrabajoByIdQuery(id);

            //Assert
            Assert.Equal(id, query.id);
        }
    }
}
