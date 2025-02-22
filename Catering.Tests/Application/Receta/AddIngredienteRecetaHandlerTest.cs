using Azure.Core;
using Catering.Application.Comidas.CrearComida;
using Catering.Application.Receta.AddIngredienteReceta;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Catering.Infrastructure.Repositories;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.OrdenesTrabajo.EventHandlers
{
    public class AddIngredienteRecetaHandlerTest
    {        
        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public AddIngredienteRecetaHandlerTest()
        {
            _recetaRepository = new Mock<IRecetaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }


        //var orden = await _recetaRepository.GetByIdAsync(request.idReceta);
        //if (orden == null) throw new Exception("Receta no puede ser nulo para agregar el ingrediente");
        //orden.AddIngrediente(request.idIngrediente, request.detalle, request.cantidad);
        //await _recetaRepository.UpdateAsync(orden);
        //await _unitOfWork.CommitAsync(cancellationToken);
        //return orden.Id;

        [Fact]
        public async Task AddIngredienteRecetaHandler()
        {
            // Arrange
            Guid idReceta = Guid.NewGuid();
            string nombreReceta = "Receta 1";
            Guid idIngrediente = Guid.NewGuid();

            var receta = new Receta(idReceta, nombreReceta);

            _recetaRepository.Setup(x => x.GetByIdAsync(idReceta, false))
                .ReturnsAsync(receta);

            _recetaRepository.Setup(x => x.UpdateAsync(It.IsAny<Receta>()));

            AddIngredienteRecetaHandler addIngredienteRecetaHandler = new AddIngredienteRecetaHandler(_recetaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await addIngredienteRecetaHandler.Handle(new AddIngredienteRecetaCommand(idReceta, idIngrediente, "", 1), tcs.Token);

            //Assert
            _recetaRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), false), Times.Once);
            _recetaRepository.Verify(x => x.UpdateAsync(It.IsAny<Receta>()), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
    }
}
