using Catering.Application.Comidas.EmpaquetarComida;
using Catering.Application.OrdenesTrabajo.PrepararReceta;
using Catering.Domain.Abstractions;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Receta.UpdateNombreReceta
{
    public class UpdateNombreRecetaHandler : IRequestHandler<UpdateNombreRecetaCommand, Guid>
    {
        private readonly IRecetaRepository _recetaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateNombreRecetaHandler(IRecetaRepository recetaRepository,
            IUnitOfWork unitOfWork)
        {
            _recetaRepository = recetaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateNombreRecetaCommand request, CancellationToken cancellationToken)
        {
            var orden = await _recetaRepository.GetByIdAsync(request.id);

            if (orden == null) throw new Exception("Receta no puede ser nulo para actualizar su nombre");

            orden.UpdateNombre(request.nombre);

            await _recetaRepository.UpdateAsync(orden);

            await _unitOfWork.CommitAsync(cancellationToken);

            return orden.Id;
        }
    }
}
