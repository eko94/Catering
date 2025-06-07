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

namespace Catering.Application.Contratos.CrearContrato
{
    public class CrearContratoHandler : IRequestHandler<CrearContratoCommand, Guid>
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IContratoFactory _contratoFactory;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPlanAlimentarioRepository _planAlimentarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearContratoHandler(IContratoRepository contratoRepository,
            IContratoFactory contratoFactory,
            IClienteRepository clienteRepository,
            IPlanAlimentarioRepository planAlimentarioRepository,
            IUnitOfWork unitOfWork) {
            _contratoRepository = contratoRepository;
            _contratoFactory = contratoFactory;
            _clienteRepository = clienteRepository;
            _planAlimentarioRepository = planAlimentarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearContratoCommand request, CancellationToken cancellationToken) {
            var contrato = await _contratoRepository.GetByIdAsync(request.idContrato);
            if (contrato != null)
            {
                throw new ArgumentException("Contrato ya ha sido creado");
            }

            var cliente = await _clienteRepository.GetByIdAsync(request.idCliente);
            if (cliente == null)
            {
                throw new ArgumentException("Cliente no es válido");
            }

            var plan = await _planAlimentarioRepository.GetByIdAsync(request.idPlanAlimentario);
            if (plan == null)
            {
                throw new ArgumentException("Plan alimentario no es válido");
            }

            var contratoCreado = _contratoFactory.CreateContrato(request.idContrato, request.idCliente, request.idPlanAlimentario, plan.CantidadDias, DateTime.Today);

            await _contratoRepository.AddAsync(contratoCreado);

            await _unitOfWork.CommitAsync(cancellationToken);

            return contratoCreado.Id;
        }
    }
}