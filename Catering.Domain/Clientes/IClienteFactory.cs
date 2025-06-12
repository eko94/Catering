using Catering.Domain.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Clientes
{
    public interface IClienteFactory
    {
        Cliente CreateCliente(Guid idCliente, string nombre);
    }
}
