using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.PlanAlimentario
{
    public class PlanAlimentarioFactory : IPlanAlimentarioFactory
    {
        public PlanAlimentario CreatePlanAlimentario(Guid idPlanAlimentario, string nombre, string tipo, int cantidadDias, List<Guid> recetas)
        {
            if (idPlanAlimentario == Guid.Empty)
            {
                throw new ArgumentException("El ID del plan alimentario no puede ser vacío", nameof(idPlanAlimentario));
            }
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del plan alimentario no puede ser nulo o vacío", nameof(nombre));
            }
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo del plan alimentario no puede ser nulo o vacío", nameof(tipo));
            }
            if (cantidadDias <= 0)
            {
                throw new ArgumentException("La cantidad de días debe ser mayor a 0", nameof(cantidadDias));
            }
            if (recetas == null || !recetas.Any() || recetas.Count != cantidadDias)
            {
                throw new ArgumentException("El plan alimentario debe tener la misma cantidad de recetas a la cantidad de días", nameof(recetas));
            }

            var planAlimentarioRecetas = recetas.Select((x, i) => new PlanAlimentarioReceta(idPlanAlimentario, x, (i + 1))).ToList();

            return new PlanAlimentario(idPlanAlimentario, nombre, tipo, cantidadDias, planAlimentarioRecetas);
        }
    }
}
