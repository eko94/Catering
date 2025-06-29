using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo.Events
{
    public record OrdenTrabajoFinalizado(Guid IdOrdenTrabajo, ICollection<OrdenTrabajoFinalizadoComida> Comidas) : DomainEvent;

    public record OrdenTrabajoFinalizadoComida(Guid IdComida, string Nombre, Guid IdCliente, Guid IdContrato);
}