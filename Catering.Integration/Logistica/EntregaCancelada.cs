using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Integration.Logistica
{
    public record EntregaCancelada : IntegrationMessage
    {
        public Guid IdCliente { get; set; }
        public Guid IdContrato { get; set; }
        public DateTime FechaCancelada { get; set; }

        public EntregaCancelada(Guid idCliente, Guid idContrato, DateTime fechaCancelada, string? correlationId = null, string? source = null)
            : base(correlationId, source)
        {
            IdCliente = idCliente;
            IdContrato = idContrato;
            FechaCancelada = fechaCancelada;
        }
    }
}
