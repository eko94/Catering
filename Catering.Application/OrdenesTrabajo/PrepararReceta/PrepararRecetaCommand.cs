using MediatR;

namespace Catering.Application.OrdenesTrabajo.PrepararReceta
{
    public record PrepararRecetaCommand(Guid id) : IRequest<Guid>;
}
