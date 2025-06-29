using Catering.Domain.OrdenesTrabajo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.CrearOrden
{
    public record CrearOrdenCommand(Guid idUsuarioCocinero, Guid idReceta, int cantidad, ICollection<CrearOrdenClienteCommand> ordenClientes) : IRequest<Guid>;

    public record CrearOrdenClienteCommand(Guid idCliente, Guid idContrato);
}
