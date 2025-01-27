using MediatR;

namespace Catering.Application.OrdenesTrabajo.CancelarOrden
{
    public record CancelarOrdenCommand(Guid id) : IRequest<Guid>;
}
