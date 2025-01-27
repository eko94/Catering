using MediatR;

namespace Catering.Application.Receta.AddIngredienteReceta
{
    public record AddIngredienteRecetaCommand(Guid idReceta, Guid idIngrediente, string detalle, float cantidad) : IRequest<Guid>;
}
