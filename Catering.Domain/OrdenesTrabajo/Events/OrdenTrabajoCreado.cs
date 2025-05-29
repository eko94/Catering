using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo.Events
{
    public record OrdenTrabajoCreado : DomainEvent
    {
        public Guid IdUsuarioCocinero { get; }
        public Guid IdReceta { get; }
        public int Cantidad { get; }
        public List<Guid> Clientes { get; init; }

        public OrdenTrabajoCreado(Guid idUsuarioCocinero, Guid idReceta, int cantidad, List<Guid> clientes)
        {
            this.IdUsuarioCocinero = idUsuarioCocinero;
            this.IdReceta = idReceta;
            this.Cantidad = cantidad;
            this.Clientes = clientes;
        }

        public OrdenTrabajoCreado()
        {
            this.Clientes = new List<Guid>();
        }
    }
}
