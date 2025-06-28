using Catering.Application.Comidas.CrearComida;
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
    public class CrearComidaHandlerTest
    {        
        private readonly Mock<IComidaRepository> _comidaRepository;
        private readonly Mock<IComidaFactory> _comidaFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CrearComidaHandlerTest()
        {
            _comidaRepository = new Mock<IComidaRepository>();
            _comidaFactory = new Mock<IComidaFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task CrearComidaHandler()
        {
            // Arrange
            Guid idComida = Guid.NewGuid();            
            string nombreComida = "Comida 1";
            Guid idOrdenTrabajo = Guid.NewGuid();

            _comidaFactory.Setup(x => x.CreateComida(nombreComida, idOrdenTrabajo))
                .Returns(new Comida(idComida, nombreComida, idOrdenTrabajo));

            _comidaRepository.Setup(x => x.AddAsync(It.IsAny<Comida>()));
                        
            CrearComidaHandler crearComidaHandler = new CrearComidaHandler(_comidaFactory.Object, _comidaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await crearComidaHandler.Handle(new CrearComidaCommand(nombreComida, idOrdenTrabajo), tcs.Token);

            //Assert
            _comidaRepository.Verify(x => x.AddAsync(It.IsAny<Comida>()), Times.Once);            
            _comidaFactory.Verify(x => x.CreateComida(nombreComida, idOrdenTrabajo), Times.Once);            
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
    }
}
