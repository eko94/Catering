using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Comidas.CrearComida
{
    public record CrearComidaCommand(Guid id, string nombre) : IRequest<Guid>;
}
