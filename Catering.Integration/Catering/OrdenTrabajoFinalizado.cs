using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Integration.Catering
{
    public record OrdenTrabajoFinalizado : IntegrationMessage
    {
        public Guid IdOrdenTrabajo { get; set; }
        public ICollection<OrdenTrabajoFinalizadoComida> Comidas { get; set; }

        public OrdenTrabajoFinalizado(Guid idOrdenTrabajo, List<OrdenTrabajoFinalizadoComida> comidas, string? correlationId = null, string? source = null)
            : base(correlationId, source)
        {
            this.IdOrdenTrabajo = idOrdenTrabajo;
            this.Comidas = comidas;
        }
    }

    public record OrdenTrabajoFinalizadoComida //: IntegrationMessage
    {
        public Guid IdComida { get; set; }
        public string Nombre { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdContrato { get; set; }

        //public OrdenTrabajoFinalizadoComida(Guid id, string nombre, Guid idCliente, string? correlationId = null, string? source = null)
        //    : base(correlationId, source)
        public OrdenTrabajoFinalizadoComida(Guid id, string nombre, Guid idCliente, Guid idContrato)
        {
            this.IdComida = id;
            this.Nombre = nombre;
            this.IdCliente = idCliente;
            this.IdContrato = idContrato;
        }
    }
}
