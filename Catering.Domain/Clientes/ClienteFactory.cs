using Catering.Domain.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Clientes
{
    public class ClienteFactory : IClienteFactory
    {
        public Cliente CreateCliente(Guid idCliente, string nombre)
        {
            if (idCliente == Guid.Empty)
            {
                throw new ArgumentException("ID Cliente no puede ser nulo", nameof(idCliente));
            }
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentNullException("Nombre no puede ser nulo o vacío", nameof(nombre));
            }

            return new Cliente(idCliente, nombre);
        }
    }
}
