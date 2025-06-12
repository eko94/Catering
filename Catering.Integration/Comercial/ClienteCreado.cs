using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Integration.Comercial
{
    public record ClienteCreado : IntegrationMessage
    {
        public string Nombre { get; set; }

        public ClienteCreado(Guid id, string nombre, string? correlationId = null, string? source = null)
            : base(correlationId, source)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
