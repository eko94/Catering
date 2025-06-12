using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.PlanAlimentario.CrearPlan
{
    public class CrearPlanHandler : IRequestHandler<CrearPlanCommand, Guid>
    {
        private readonly IPlanAlimentarioRepository _planAlimentarioRepository;
        private readonly IPlanAlimentarioFactory _planAlimentarioFactory;
        private readonly IRecetaRepository _recetaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPlanHandler(IPlanAlimentarioRepository planAlimnetarioRepository,
            IPlanAlimentarioFactory planAlimentarioFactory,
            IRecetaRepository recetaRepository,
            IUnitOfWork unitOfWork) {
            _planAlimentarioRepository = planAlimnetarioRepository;
            _planAlimentarioFactory = planAlimentarioFactory;
            _recetaRepository = recetaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearPlanCommand request, CancellationToken cancellationToken) {
            var planAlimentario = await _planAlimentarioRepository.GetByIdAsync(request.idPlanAlimentario);
            if (planAlimentario != null)
            {
                throw new ArgumentException("El plan alimentario ya existe");
            }

            var recetas = await _recetaRepository.GetRandomIdRecetas(request.cantidadDias);

            var plan = _planAlimentarioFactory.CreatePlanAlimentario(request.idPlanAlimentario, request.nombre, request.tipo, request.cantidadDias, recetas);

            await _planAlimentarioRepository.AddAsync(plan);

            await _unitOfWork.CommitAsync(cancellationToken);

            return plan.Id;
        }
    }
}