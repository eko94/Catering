using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Usuarios
{
    public class Usuario : AggregateRoot
    {
        public string Nombre { get; set; }

        public Usuario(Guid id, string nombre) : base(id)
        {
            Nombre = nombre;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private Usuario() { }
    }
}
