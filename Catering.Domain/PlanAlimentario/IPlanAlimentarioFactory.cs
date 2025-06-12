using Catering.Domain.OrdenesTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.PlanAlimentario
{
    public interface IPlanAlimentarioFactory
    {
        PlanAlimentario CreatePlanAlimentario(Guid idPlanAlimentario, string nombre, string tipo, int cantidadDias, List<Guid> recetas);
    }
}
