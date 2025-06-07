using Catering.Domain.Clientes;
using Catering.Domain.Contratos;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Contratos
{
    public class ContratoFactory : IContratoFactory
    {
        public Contrato CreateContrato(Guid idContrato, Guid idCliente, Guid idPlanAlimentario, int diasContratados, DateTime fechaInicio)
        {
            if (idContrato == Guid.Empty)
            {
                throw new ArgumentException("Contrato no puede ser vacío", nameof(idContrato));
            }
            if (idCliente == Guid.Empty)
            {
                throw new ArgumentNullException("Cliente no puede ser nulo", nameof(idCliente));
            }
            if (idPlanAlimentario == Guid.Empty)
            {
                throw new ArgumentNullException("Plan Alimentario no puede ser nulo", nameof(idPlanAlimentario));
            }
            if (diasContratados <= 0)
            {
                throw new ArgumentException("Días Contratados debe ser mayor a 0", nameof(diasContratados));
            }
            return new Contrato(idContrato, idCliente, idPlanAlimentario, diasContratados, fechaInicio);
        }
    }
}
