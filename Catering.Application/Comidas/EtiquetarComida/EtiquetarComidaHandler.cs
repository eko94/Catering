using Catering.Application.Comidas.CrearComida;
using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Comidas.EmpaquetarComida
{
    public class EtiquetarComidaHandler : IRequestHandler<EtiquetarComidaCommand, Guid>
    {
        private readonly IOrdenTrabajoRepository _ordenTrabajoRepository;
        private readonly IComidaRepository _comidaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EtiquetarComidaHandler(IOrdenTrabajoRepository ordenTrabajoRepository,
            IComidaRepository comidaRepository,
            IUnitOfWork unitOfWork)
        {
            _ordenTrabajoRepository = ordenTrabajoRepository;
            _comidaRepository = comidaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(EtiquetarComidaCommand request, CancellationToken cancellationToken)
        {
            var orden = await _ordenTrabajoRepository.GetByIdAsync(request.idOrden);

            if (orden == null) throw new Exception("Orden no puede ser nulo para etiquetar");

            orden.EtiquetarComidas();
            
            await _ordenTrabajoRepository.UpdateAsync(orden);

            await _unitOfWork.CommitAsync(cancellationToken);

            return orden.Id;
        }
    }
}
