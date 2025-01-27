using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Clientes
{
    public class Cliente : AggregateRoot
    {
        public string Nombre { get; set; }

        public Cliente(Guid id, string  nombre) : base(id)
        {
            Nombre = nombre;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private Cliente() { }
    }
}
