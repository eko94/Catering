using Catering.Application.Comidas.CrearComida;
using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Comidas.EmpaquetarComida
{
    public class EmpaquetarComidaHandler : IRequestHandler<EmpaquetarComidaCommand, Guid>
    {
        private readonly IComidaRepository _comidaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmpaquetarComidaHandler(IComidaRepository comidaRepository,
            IUnitOfWork unitOfWork)
        {
            _comidaRepository = comidaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(EmpaquetarComidaCommand request, CancellationToken cancellationToken)
        {
            var comida = await _comidaRepository.GetByIdAsync(request.id);

            if (comida == null) throw new Exception("Comida no puede ser nulo para empaquetar");

            comida.Empaquetar();

            await _comidaRepository.UpdateAsync(comida);

            await _unitOfWork.CommitAsync(cancellationToken);

            return comida.Id;
        }
    }
}
