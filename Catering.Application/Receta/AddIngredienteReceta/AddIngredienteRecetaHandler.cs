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
            var orden = await _recetaRepository.GetByIdAsync(request.idReceta);

            if (orden == null) throw new Exception("Receta no puede ser nulo para agregar el ingrediente");

            orden.AddIngrediente(request.idIngrediente, request.detalle, request.cantidad);

            await _recetaRepository.UpdateAsync(orden);

            await _unitOfWork.CommitAsync(cancellationToken);

            return orden.Id;
        }
    }
}
