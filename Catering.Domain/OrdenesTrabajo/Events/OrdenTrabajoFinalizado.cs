using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo.Events
{
    public record OrdenTrabajoFinalizado : DomainEvent
    {
        public Guid Id { get; set; }
        public ICollection<OrdenTrabajoFinalizadoComida> Comidas { get; set; }

        public OrdenTrabajoFinalizado(Guid id, List<OrdenTrabajoFinalizadoComida> comidas)
        {
            this.Id = id;
            this.Comidas = comidas;
        }
        public OrdenTrabajoFinalizado()
        {
            this.Comidas = new List<OrdenTrabajoFinalizadoComida>();
        }
    }

    public record OrdenTrabajoFinalizadoComida : DomainEvent
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid IdCliente { get; set; }

        public OrdenTrabajoFinalizadoComida(Guid id, string nombre, Guid idCliente)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.IdCliente = idCliente;
        }
    }
}
