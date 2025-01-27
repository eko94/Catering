using Catering.Application.Comidas.EmpaquetarComida;
using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.PrepararReceta
{
    public class PrepararRecetaHandler : IRequestHandler<PrepararRecetaCommand, Guid>
    {
        private readonly IOrdenTrabajoRepository _ordenTrabajoRepository;
        private readonly IRecetaRepository _recetaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PrepararRecetaHandler(IOrdenTrabajoRepository ordenTrabajoRepository,
            IRecetaRepository recetaRepository,
            IUnitOfWork unitOfWork)
        {
            _ordenTrabajoRepository = ordenTrabajoRepository;
            _recetaRepository = recetaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(PrepararRecetaCommand request, CancellationToken cancellationToken)
        {
            var orden = await _ordenTrabajoRepository.GetByIdAsync(request.id);

            if (orden == null) throw new Exception("Orden de trabajo no puede ser nulo para preparar la receta");            

            orden.PrepararReceta();

            await _ordenTrabajoRepository.UpdateAsync(orden);

            await _unitOfWork.CommitAsync(cancellationToken);

            return orden.Id;
        }
    }
}