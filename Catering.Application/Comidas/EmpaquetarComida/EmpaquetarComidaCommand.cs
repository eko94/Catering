using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Comidas.EmpaquetarComida
{
    public record EmpaquetarComidaCommand(Guid id) : IRequest<Guid>;
}
