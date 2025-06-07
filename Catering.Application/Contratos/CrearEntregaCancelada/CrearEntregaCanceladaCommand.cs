using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Contratos.CrearEntregaCancelada
{
    public record CrearEntregaCanceladaCommand(Guid idContrato, DateTime fechaCancelada) : IRequest<Guid>;
}