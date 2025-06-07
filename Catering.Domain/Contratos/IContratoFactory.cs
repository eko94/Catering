using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Contratos
{
    public interface IContratoFactory
    {
        Contrato CreateContrato(Guid idContrato, Guid idCliente, Guid idPlanAlimentario, int diasContratados, DateTime fechaInicio);
    }
}
