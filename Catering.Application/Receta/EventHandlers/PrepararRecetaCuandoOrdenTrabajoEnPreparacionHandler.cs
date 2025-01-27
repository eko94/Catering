using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.OrdenesTrabajo.Events;
using Catering.Domain.Recetas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Receta.EventHandlers
{
    public record PrepararRecetaCuandoOrdenTrabajoEnPreparacionHandler : INotificationHandler<OrdenTrabajoEnPreparacionEvent>
    {
        private readonly IRecetaRepository _recetaRepository;
        private readonly IOrdenTrabajoRepository _ordenTrabajoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PrepararRecetaCuandoOrdenTrabajoEnPreparacionHandler(IRecetaRepository recetaRepository, IOrdenTrabajoRepository ordenTrabajoRepository, IUnitOfWork unitOfWork)
        {
            _recetaRepository = recetaRepository;            
            _ordenTrabajoRepository = ordenTrabajoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(OrdenTrabajoEnPreparacionEvent domainEvent, CancellationToken cancellationToken)
        {
            var receta = await _recetaRepository.GetByIdAsync(domainEvent.IdReceta);
            if(receta == null)
            {
                throw new ArgumentException("Receta no puede ser nulo");
            }

            var ordenTrabajo = await _ordenTrabajoRepository.GetByIdAsync(domainEvent.IdOrdenTrabajo);
            if (ordenTrabajo == null)
            {
                throw new ArgumentException("Orden Trabajo no puede ser nulo");
            }

            var comidas = new List<Comida>();
            for(var i = 0; i < domainEvent.Cantidad; i++)
            {
                comidas.Add(receta.PrepararReceta(domainEvent.IdOrdenTrabajo));
            }

            ordenTrabajo.SetComidasPreparadas(comidas);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
