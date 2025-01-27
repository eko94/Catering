using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.EtiquetarComidas
{
    public record EtiquetarComidasCommand(Guid id) : IRequest<Guid>;
}
