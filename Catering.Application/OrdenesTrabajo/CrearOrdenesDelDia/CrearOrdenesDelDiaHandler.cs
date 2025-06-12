using Catering.Application.Contratos.GetContratosRealizarDelDia;
using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Catering.Application.OrdenesTrabajo.CrearOrdenesDelDia
{
    public class CrearOrdenesDelDiaHandler : IRequestHandler<CrearOrdenesDelDiaCommand>
    {
        private readonly IOrdenTrabajoRepository _ordenTrabajoRepository;
        private readonly IOrdenTrabajoFactory _ordenTrabajoFactory;
        private readonly IContratoRepository _contratoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public CrearOrdenesDelDiaHandler(IOrdenTrabajoRepository ordenTrabajoRepository,
            IOrdenTrabajoFactory ordenTrabajoFactory,
            IContratoRepository contratoRepository,
            IUsuarioRepository usuarioRepository,
            IClienteRepository clienteRepository,
            IMediator mediator,
            IUnitOfWork unitOfWork) {
            _ordenTrabajoRepository = ordenTrabajoRepository;
            _ordenTrabajoFactory = ordenTrabajoFactory;
            _contratoRepository = contratoRepository;
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CrearOrdenesDelDiaCommand request, CancellationToken cancellationToken) {
            var contratos = await _mediator.Send(new GetContratosRealizarDelDiaQuery(), cancellationToken);

            if (contratos == null || !contratos.Any()) return;

            var idCocinero = await _usuarioRepository.GetRandomIdCocinero();

            var ordenesTrabajo =
               (from res in contratos
                group res by new { res.IdContrato, res.IdReceta } into g
                select _ordenTrabajoFactory.CreateOrdenTrabajo(idCocinero, g.Key.IdReceta, g.Count(), g.Select(x => x.IdCliente).ToList()))
                .ToList();

            foreach (var con in contratos)
            {
                var contrato = await _contratoRepository.GetByIdAsync(con.IdContrato);
                if (contrato == null) continue;
                contrato.UpdateEstado();
                await _contratoRepository.UpdateAsync(contrato);
            }

            await _ordenTrabajoRepository.AddRangeAsync(ordenesTrabajo);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}