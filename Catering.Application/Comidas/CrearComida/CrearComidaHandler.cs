using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Comidas.CrearComida
{
    public class CrearComidaHandler : IRequestHandler<CrearComidaCommand, Guid>
    {
        private readonly IComidaFactory _comidaFactory;
        private readonly IComidaRepository _comidaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearComidaHandler(IComidaFactory comidaFactory,
            IComidaRepository comidaRepository, 
            IUnitOfWork unitOfWork)
        {            
            _comidaFactory = comidaFactory;
            _comidaRepository = comidaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearComidaCommand request, CancellationToken cancellationToken)
        {
            var comida = _comidaFactory.CreateComida(request.id, request.nombre);

            await _comidaRepository.AddAsync(comida);

            await _unitOfWork.CommitAsync(cancellationToken);

            return comida.Id;
        }
    }
}
