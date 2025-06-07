using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.PlanAlimentario.CrearPlan
{
    public class CrearPlanHandler : IRequestHandler<CrearPlanCommand, Guid>
    {
        private readonly IPlanAlimentarioRepository _planAlimentarioRepository;
        private readonly IPlanAlimentarioFactory _planAlimentarioFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPlanHandler(IPlanAlimentarioRepository planAlimnetarioRepository,
            IPlanAlimentarioFactory planAlimentarioFactory,
            IUnitOfWork unitOfWork) {
            _planAlimentarioRepository = planAlimnetarioRepository;
            _planAlimentarioFactory = planAlimentarioFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearPlanCommand request, CancellationToken cancellationToken) {
            var planAlimentario = await _planAlimentarioRepository.GetByIdAsync(request.idPlanAlimentario);
            if (planAlimentario != null)
            {
                throw new ArgumentException("El plan alimentario ya existe");
            }

            var plan = _planAlimentarioFactory.CreatePlanAlimentario(request.idPlanAlimentario, request.nombre, request.tipo, request.cantidadDias);

            await _planAlimentarioRepository.AddAsync(plan);

            await _unitOfWork.CommitAsync(cancellationToken);

            return plan.Id;
        }
    }
}