using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Clientes.CrearCliente
{
    public record CrearClienteCommand(Guid idCliente, string nombre) : IRequest<Guid>;
}