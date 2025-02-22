using Catering.Application.Comidas.EmpaquetarComida;
using Catering.Application.OrdenesTrabajo.PrepararReceta;
using Catering.Domain.Abstractions;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Receta.AddIngredienteReceta
{
    public class AddIngredienteRecetaHandler : IRequestHandler<AddIngredienteRecetaCommand, Guid>
    {
        private readonly IRecetaRepository _recetaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddIngredienteRecetaHandler(IRecetaRepository recetaRepository,
            IUnitOfWork unitOfWork)
        {
            _recetaRepository = recetaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddIngredienteRecetaCommand request, CancellationToken cancellationToken)
        {
            var receta = await _recetaRepository.GetByIdAsync(request.idReceta);

            if (receta == null) throw new Exception("Receta no puede ser nulo para agregar el ingrediente");

            receta.AddIngrediente(request.idIngrediente, request.detalle, request.cantidad);

            await _recetaRepository.UpdateAsync(receta);

            await _unitOfWork.CommitAsync(cancellationToken);

            return receta.Id;
        }
    }
}
