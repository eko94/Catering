using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo.Events
{
    public record OrdenTrabajoEnPreparacionEvent : DomainEvent
    {
        public Guid IdOrdenTrabajo { get; init; }
        public Guid IdReceta { get; init; }
        public int Cantidad { get; init; }


        public OrdenTrabajoEnPreparacionEvent(Guid idOrdenTrabajo,
            Guid idReceta,
            int cantidad)
        {
            IdOrdenTrabajo = idOrdenTrabajo;
            IdReceta = idReceta;
            Cantidad = cantidad;
        }
    }
}
