using MediatR;

namespace Catering.Application.Receta.UpdateNombreReceta
{
    public record UpdateNombreRecetaCommand(Guid id, string nombre) : IRequest<Guid>;
}
