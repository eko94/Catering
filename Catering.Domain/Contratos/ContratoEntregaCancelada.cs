using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Contratos
{
    public class ContratoEntregaCancelada : Entity
    {
        public Guid IdContrato { get; private set; }
        public DateTime FechaCancelada { get; private set; }

        public ContratoEntregaCancelada(Guid idContrato, DateTime fechaCancelada) : base(Guid.NewGuid())
        {
            IdContrato = idContrato;
            FechaCancelada = fechaCancelada;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private ContratoEntregaCancelada() { }
    }
}
