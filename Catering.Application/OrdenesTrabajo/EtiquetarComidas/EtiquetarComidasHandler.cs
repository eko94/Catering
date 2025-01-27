using Catering.Application.Comidas.EmpaquetarComida;
using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.EtiquetarComidas
{
    public class EtiquetarComidasHandler : IRequestHandler<EtiquetarComidasCommand, Guid>
    {
        private readonly IOrdenTrabajoRepository _ordenTrabajoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EtiquetarComidasHandler(IOrdenTrabajoRepository ordenTrabajoRepository,
            IUnitOfWork unitOfWork)
        {
            _ordenTrabajoRepository = ordenTrabajoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(EtiquetarComidasCommand request, CancellationToken cancellationToken)
        {
            var orden = await _ordenTrabajoRepository.GetByIdAsync(request.id);

            if (orden == null) throw new Exception("Orden de trabajo no puede ser nulo para preparar la receta");

            orden.EtiquetarComidas();

            await _ordenTrabajoRepository.UpdateAsync(orden);

            await _unitOfWork.CommitAsync(cancellationToken);

            return orden.Id;
        }
    }
}
