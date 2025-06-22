using Catering.Domain.OrdenesTrabajo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.GetOrdenesTrabajo
{
    public record GetOrdenesTrabajoByUserStateQuery(Guid idUsuario, string? status) : IRequest<IEnumerable<GetOrdenesTrabajoByUserStateDto>>;
}
