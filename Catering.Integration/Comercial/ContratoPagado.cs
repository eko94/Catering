using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Integration.Comercial
{
    public record ContratoPagado : IntegrationMessage
    {
        public Guid IdContrato { get; set; }
        public Guid IdPlanAlimentario { get; set; }
        public int DiasContratado { get; set; }
                
        public ContratoPagado(Guid idContrato, Guid idPlanAlimentario, int diasContratado)
        {
            IdContrato = idContrato;
            IdPlanAlimentario = idPlanAlimentario;
            DiasContratado = diasContratado;
        }

        public ContratoPagado()
        {
        }
    }
}
