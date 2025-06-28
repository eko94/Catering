using Catering.Application.Contratos.GetContratosRealizarDelDia;
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
    public class GetContratosRealizarDelDiaTest
    {
        [Fact]
        public async Task GetContratosRealizarDelDiaDtoCreacionEsValido()
        {
            // Arrange
            GetContratosRealizarDelDiaDto dto = new GetContratosRealizarDelDiaDto();
            Guid id = Guid.NewGuid();
            Guid idCliente = Guid.NewGuid();
            Guid idReceta = Guid.NewGuid();            

            //Act            
            dto.IdContrato = id;
            dto.IdCliente = idCliente;
            dto.IdReceta = idReceta;

            //Assert
            Assert.Equal(id, dto.IdContrato);
            Assert.Equal(idCliente, dto.IdCliente);
            Assert.Equal(idReceta, dto.IdReceta);
        }

        [Fact]
        public void GetContratosRealizarDelDiaQueryEsValido()
        {
            // Arrange

            //Act
            GetContratosRealizarDelDiaQuery query = new GetContratosRealizarDelDiaQuery();

            //Assert
            Assert.NotNull(query);
        }
    }
}
