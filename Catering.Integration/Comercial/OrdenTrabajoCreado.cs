using Joseco.Communication.External.Contracts.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Integration.Comercial
{
    public record OrdenTrabajoCreado : IntegrationMessage
    {
        public Guid IdUsuarioCocinero { get; set; }
        public Guid IdReceta { get; set; }
        public int Cantidad { get; set; }
        public List<Guid> Clientes { get; set; }

        public OrdenTrabajoCreado(Guid idUsuarioCocinero, Guid idReceta, int cantidad, List<Guid> clientes)
        {
            this.IdUsuarioCocinero = idUsuarioCocinero;
            this.IdReceta = idReceta;
            this.Cantidad = cantidad;
            this.Clientes = clientes;
        }

        public OrdenTrabajoCreado()
        {
            Clientes = new List<Guid>();
        }
    }
}
