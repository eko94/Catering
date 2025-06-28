using Catering.Application.Comidas.CrearComida;
using Catering.Application.Comidas.EmpaquetarComida;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.Comidas.EventHandlers
{
    public class EmpaquetarComidaHandlerTest
    {        
        private readonly Mock<IComidaRepository> _comidaRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public EmpaquetarComidaHandlerTest()
        {
            _comidaRepository = new Mock<IComidaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        //var comida = await _comidaRepository.GetByIdAsync(request.id);
        //if (comida == null) throw new Exception("Comida no puede ser nulo para empaquetar");
        //comida.Empaquetar();
        //await _comidaRepository.UpdateAsync(comida);
        //await _unitOfWork.CommitAsync(cancellationToken);
        //return comida.Id;

        [Fact]
        public async Task EmpaquetarComidaHandler()
        {
            // Arrange
            Guid idComida = Guid.NewGuid();            
            string nombreComida = "Comida 1";
            Guid idOrdenTrabajo = Guid.NewGuid();

            var comida = new Comida(idComida, nombreComida, idOrdenTrabajo);

            List<RecetaIngrediente> ingredientes = new List<RecetaIngrediente>
            {
                new RecetaIngrediente(Guid.NewGuid(), Guid.NewGuid(), string.Empty, 1)
            };

            comida.Preparar(ingredientes);

            _comidaRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(comida);

            _comidaRepository.Setup(x => x.UpdateAsync(It.IsAny<Comida>()));
                        
            EmpaquetarComidaHandler empaquetarComidaHandler = new EmpaquetarComidaHandler(_comidaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await empaquetarComidaHandler.Handle(new EmpaquetarComidaCommand(idComida), tcs.Token);

            //Assert
            _comidaRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), false), Times.Once);            
            _comidaRepository.Verify(x => x.UpdateAsync(It.IsAny<Comida>()), Times.Once);            
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
    }
}
