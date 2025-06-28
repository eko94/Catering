using Azure.Core;
using Catering.Application.PlanAlimentario.CrearPlan;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using Catering.Infrastructure.Repositories;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.PlanesAlimentarios.EventHandlers
{
    public class CrearPlanAlimentarioHandlerTest
    {        
        
        private readonly Mock<IPlanAlimentarioFactory> _planAlimentarioFactory;
        private readonly Mock<IPlanAlimentarioRepository> _planAlimentarioRepository;
        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CrearPlanAlimentarioHandlerTest()
        {
            _planAlimentarioRepository = new Mock<IPlanAlimentarioRepository>();
            _planAlimentarioFactory = new Mock<IPlanAlimentarioFactory>();
            _recetaRepository = new Mock<IRecetaRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task CrearPlanAlimentarioHandler()
        {
            // Arrange
            Guid idPlanAlimentario = Guid.NewGuid();
            string nombre = "Plan 1";
            string tipo = "Plan";
            int cantidadDias = 15;

            PlanAlimentario planAlimentario = new PlanAlimentario(idPlanAlimentario, nombre, tipo, cantidadDias, new List<PlanAlimentarioReceta>());

            _planAlimentarioFactory.Setup(x => x.CreatePlanAlimentario(idPlanAlimentario, nombre, tipo, cantidadDias, new List<Guid>()))
                .Returns(planAlimentario);

            _recetaRepository.Setup(x => x.GetRandomIdRecetas(cantidadDias))
                .ReturnsAsync(new List<Guid>());

            _planAlimentarioRepository.Setup(x => x.AddAsync(It.IsAny<PlanAlimentario>()));

            CrearPlanHandler crearPlanAlimentarioHandler = new CrearPlanHandler(_planAlimentarioRepository.Object, _planAlimentarioFactory.Object,
                _recetaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            await crearPlanAlimentarioHandler.Handle(new CrearPlanCommand(idPlanAlimentario, nombre, tipo, cantidadDias), tcs.Token);

            //Assert
            _planAlimentarioRepository.Verify(x => x.AddAsync(It.IsAny<PlanAlimentario>()), Times.Once);
            _planAlimentarioFactory.Verify(x => x.CreatePlanAlimentario(idPlanAlimentario, nombre, tipo, cantidadDias, new List<Guid>()), Times.Once);
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Once);
        }
    }
}
