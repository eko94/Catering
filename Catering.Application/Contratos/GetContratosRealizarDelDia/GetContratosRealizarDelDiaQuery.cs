using Catering.Application.OrdenesTrabajo.GetOrdenTrabajoById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Contratos.GetContratosRealizarDelDia
{
    public record GetContratosRealizarDelDiaQuery() : IRequest<IEnumerable<GetContratosRealizarDelDiaDto>>;
}