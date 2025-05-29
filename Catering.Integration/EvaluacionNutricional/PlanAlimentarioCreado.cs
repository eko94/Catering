using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Integration.EvaluacionNutricional
{
    public record PlanAlimentarioCreado : IntegrationMessage
    {
        public Guid IdPlanAlimentario { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public PlanAlimentarioCreado(Guid idPlanAlimentario, string nombre, string tipo)
        {
            IdPlanAlimentario = idPlanAlimentario;
            Nombre = nombre;
            Tipo = tipo;
        }

        public PlanAlimentarioCreado()
        {
        }
    }
}
