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

    public record OrdenTrabajoFinalizadoComida
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public Guid IdCliente { get; set; }
    }
}
