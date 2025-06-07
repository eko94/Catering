using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.PlanAlimentario.CrearPlan
{
    public record CrearPlanCommand(Guid idPlanAlimentario, string nombre, string tipo, int cantidadDias) : IRequest<Guid>;
}