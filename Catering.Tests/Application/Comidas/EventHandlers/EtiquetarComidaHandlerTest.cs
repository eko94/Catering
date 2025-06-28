using Catering.Application.Comidas.CrearComida;
using Catering.Application.Comidas.EmpaquetarComida;
using Catering.Application.Receta.EventHandlers;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.OrdenesTrabajo.Events;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using Moq;
using System.Threading;

namespace Catering.Tests.Application.Comidas.EventHandlers
{
    public class EtiquetarComidaHandlerTest
    {        
        private readonly Mock<IRecetaRepository> _recetaRepository;
        private readonly Mock<IOrdenTrabajoRepository> _ordenTrabajoRepository;
        private readonly Mock<IComidaRepository> _comidaRepository;
        private readonly Mock<IComidaFactory> _comidaFactory;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public EtiquetarComidaHandlerTest()
        {
            _recetaRepository = new Mock<IRecetaRepository>();
            _ordenTrabajoRepository = new Mock<IOrdenTrabajoRepository>();
            _comidaRepository = new Mock<IComidaRepository>();
            _comidaFactory = new Mock<IComidaFactory>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        //var comida = await _comidaRepository.GetByIdAsync(request.id);
        //if (comida == null) throw new Exception("Comida no puede ser nulo para empaquetar");
        //comida.Empaquetar();
        //await _comidaRepository.UpdateAsync(comida);
        //await _unitOfWork.CommitAsync(cancellationToken);
        //return comida.Id;

        [Fact]
        public async Task EtiquetarComidaHandler()
        {
            // Arrange
            Guid idComida = Guid.NewGuid();            
            string nombreComida = "Comida 1";
            Guid idOrdenTrabajo = Guid.NewGuid();
            Guid idUsuarioCocinero = Guid.NewGuid();
            Guid idReceta = Guid.NewGuid();

            var comida = new Comida(idComida, nombreComida, idOrdenTrabajo);
            List<RecetaIngrediente> ingredientes = new List<RecetaIngrediente>
            {
                new RecetaIngrediente(Guid.NewGuid(), Guid.NewGuid(), string.Empty, 1)
            };
            //comida.Preparar(ingredientes);


            string nombreReceta = "Receta 1";
            Receta receta = new Receta(idReceta, nombreReceta);

            List<Guid> clientes = new List<Guid>
            {
                Guid.NewGuid()
            };
            var ordenTrabajo = new OrdenTrabajo(idOrdenTrabajo, idUsuarioCocinero, idReceta, 1, OrdenTrabajoType.Comida, clientes);
            
            _recetaRepository.Setup(x => x.GetByIdAsync(idReceta, false))
                .ReturnsAsync(receta);

            _comidaFactory.Setup(x => x.CreateComida(nombreReceta, ordenTrabajo.Id))
                .Returns(comida);

            _comidaRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(comida);

            _comidaRepository.Setup(x => x.UpdateAsync(It.IsAny<Comida>()));

            _ordenTrabajoRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(ordenTrabajo);

            _ordenTrabajoRepository.Setup(x => x.UpdateAsync(It.IsAny<OrdenTrabajo>()));


            //var orden = await _ordenTrabajoRepository.GetByIdAsync(request.idOrden);
            //if (orden == null) throw new Exception("Orden no puede ser nulo para etiquetar");
            //orden.EtiquetarComidas();
            //await _ordenTrabajoRepository.UpdateAsync(orden);
            //await _unitOfWork.CommitAsync(cancellationToken);
            //return orden.Id;

            var prepararRecetaCuandoOrdenTrabajoEnPreparacionHandler = new PrepararRecetaCuandoOrdenTrabajoEnPreparacionHandler(_recetaRepository.Object, _ordenTrabajoRepository.Object, _unitOfWork.Object, _comidaRepository.Object, _comidaFactory.Object);
            EmpaquetarComidaHandler empaquetarComidaHandler = new EmpaquetarComidaHandler(_comidaRepository.Object, _unitOfWork.Object);
            EtiquetarComidaHandler etiquetarComidaHandler = new EtiquetarComidaHandler(_ordenTrabajoRepository.Object, _comidaRepository.Object, _unitOfWork.Object);

            var tcs = new CancellationTokenSource(1000);

            //Act
            ordenTrabajo.PrepararReceta();
            await prepararRecetaCuandoOrdenTrabajoEnPreparacionHandler.Handle(new OrdenTrabajoEnPreparacionEvent(ordenTrabajo.Id, ordenTrabajo.IdReceta, ordenTrabajo.Cantidad), tcs.Token);
            ordenTrabajo.EmpaquetarComidas();
            var comidaPreparada = new Comida(idComida, nombreComida, idOrdenTrabajo);
            comidaPreparada.Preparar(ingredientes);
            _comidaRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), false))
                .ReturnsAsync(comidaPreparada);

            await empaquetarComidaHandler.Handle(new EmpaquetarComidaCommand(idComida), tcs.Token);                        
            await etiquetarComidaHandler.Handle(new EtiquetarComidaCommand(idOrdenTrabajo), tcs.Token);

            //Assert
            _ordenTrabajoRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), false), Times.Exactly(2));
            _comidaRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), false), Times.Once);            
            _comidaRepository.Verify(x => x.UpdateAsync(It.IsAny<Comida>()), Times.Once);            
            _unitOfWork.Verify(x => x.CommitAsync(tcs.Token), Times.Exactly(3));
        }
    }
}
