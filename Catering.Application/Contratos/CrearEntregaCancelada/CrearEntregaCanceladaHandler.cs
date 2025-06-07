using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Contratos.CrearEntregaCancelada
{
    public class CrearEntregaCanceladaHandler : IRequestHandler<CrearEntregaCanceladaCommand, Guid>
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearEntregaCanceladaHandler(IContratoRepository contratoRepository,
            IClienteRepository clienteRepository,
            IUnitOfWork unitOfWork) {
            _contratoRepository = contratoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearEntregaCanceladaCommand request, CancellationToken cancellationToken) {
            var contrato = await _contratoRepository.GetByIdAsync(request.idContrato);
            if (contrato == null)
            {
                throw new ArgumentException("Contrato no es válido");
            }
            if (contrato.EntregasCanceladas.Any(x => x.FechaCancelada.Date == request.fechaCancelada.Date))
            {
                throw new ArgumentException("Ya existe una entrega cancelada para esta fecha");
            }
            if (DateTime.Today > request.fechaCancelada.Date)
            {
                throw new ArgumentException("La fecha de cancelación no puede ser anterior a la fecha actual");
            }

            ContratoEntregaCancelada ContratoEntregaCancelada = new ContratoEntregaCancelada(request.idContrato, request.fechaCancelada);

            await _contratoRepository.AddEntregaCancelada(ContratoEntregaCancelada);

            await _unitOfWork.CommitAsync(cancellationToken);

            return contrato.Id;
        }
    }
}