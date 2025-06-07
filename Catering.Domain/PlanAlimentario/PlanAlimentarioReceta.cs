using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.PlanAlimentario
{
    public class PlanAlimentarioReceta : Entity
    {
        public Guid IdPlanAlimentario { get; private set; }
        public Guid IdReceta { get; private set; }
        public PlanAlimentarioRecetaDia Dia { get; private set; }

        public PlanAlimentarioReceta(Guid idPlanAlimentario, Guid idReceta, int dia) : base(Guid.NewGuid())
        {
            IdPlanAlimentario = idPlanAlimentario;
            IdReceta = idReceta;
            Dia = dia;
        }

        public void Update(Guid idReceta, int dia)
        {
            if (dia < 1)
            {
                throw new ArgumentOutOfRangeException("Día debe ser mayor o igual 1", nameof(dia));
            }
            if (idReceta == Guid.Empty)
            {
                throw new ArgumentNullException("Receta no puede ser nulo");
            }

            IdReceta = idReceta;
            Dia = dia;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private PlanAlimentarioReceta() { }
    }
}
