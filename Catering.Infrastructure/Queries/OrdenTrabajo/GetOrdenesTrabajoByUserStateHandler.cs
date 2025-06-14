using Catering.Application.OrdenesTrabajo.GetOrdenesTrabajo;
using Catering.Infrastructure.StoredModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Queries.OrdenTrabajo
{
    public class GetOrdenesTrabajoByUserStateHandler : IRequestHandler<GetOrdenesTrabajoByUserStateQuery, IEnumerable<GetOrdenesTrabajoByUserStateDto>>
    {
        private readonly StoredDbContext _dbContext;

        public GetOrdenesTrabajoByUserStateHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetOrdenesTrabajoByUserStateDto>> Handle(GetOrdenesTrabajoByUserStateQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.OrdenTrabajo.AsNoTracking()
                .Where(x => 
                    (x.IdUsuarioCocinero == request.idUsuario || request.idUsuario == Guid.Empty)
                    && (x.Estado == request.status || string.IsNullOrEmpty(request.status)))
                .Select(x => new GetOrdenesTrabajoByUserStateDto()
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
