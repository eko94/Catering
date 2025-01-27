using Catering.Application.OrdenesTrabajo.GetOrdenesTrabajo;
using Catering.Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Handlers.OrdenTrabajo
{
    public class GetOrdenesTrabajoHandler : IRequestHandler<GetOrdenesTrabajoQuery, IEnumerable<GetOrdenesTrabajoDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetOrdenesTrabajoHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetOrdenesTrabajoDto>> Handle(GetOrdenesTrabajoQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.OrdenTrabajo.AsNoTracking()
                .Where(x => 
                    (x.IdUsuarioCocinero == request.idUsuario || request.idUsuario == Guid.Empty)
                    && (x.Estado == request.status || string.IsNullOrEmpty(request.status)))
                .Select(x => new GetOrdenesTrabajoDto()
                {
                    Id = x.Id,
                    Cantidad= x.Cantidad,
                    Estado = x.Estado,
                    RecetaNombre = x.Receta.Nombre,
                    Tipo = x.Tipo,
                    UsuarioCocineroNombre = x.UsuarioCocinero.Nombre,
                })
                .ToListAsync(cancellationToken);
        }
    }
}
