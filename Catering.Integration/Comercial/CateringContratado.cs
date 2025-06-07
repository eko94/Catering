using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Integration.Comercial
{
    public record CateringContratado : IntegrationMessage
    {
        public Guid IdContrato { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdPlanAlimentario { get; set; }

        public CateringContratado(Guid idContrato, Guid idCliente, Guid idPlanAlimentario, string? correlationId = null, string? source = null)
            : base(correlationId, source)
        {
            IdContrato = idContrato;
            IdCliente = idCliente;
            IdPlanAlimentario = idPlanAlimentario;
        }
    }
}
