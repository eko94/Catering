using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Contratos.CrearContrato
{
    public record CrearContratoCommand(Guid idContrato, Guid idCliente, Guid idPlanAlimentario) : IRequest<Guid>;
}