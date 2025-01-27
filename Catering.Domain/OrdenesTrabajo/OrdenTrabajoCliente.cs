using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo
{
    public class OrdenTrabajoCliente : Entity
    {
        public Guid IdOrdenTrabajo { get; private set; }
        public Guid IdCliente { get; private set; }

        public OrdenTrabajoCliente(Guid idOrdenTrabajo, Guid idCliente) : base(Guid.NewGuid())
        {
            IdOrdenTrabajo = idOrdenTrabajo;
            IdCliente = idCliente;
        }

        public void Update(Guid idCliente)
        {
            if (idCliente == Guid.Empty)
            {
                throw new ArgumentNullException("Cliente no puede ser nulo");
            }

            IdCliente = idCliente;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private OrdenTrabajoCliente() { }
    }
}
