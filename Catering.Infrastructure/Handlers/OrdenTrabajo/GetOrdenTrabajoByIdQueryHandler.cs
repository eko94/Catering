using Catering.Application.OrdenesTrabajo.GetOrdenTrabajoById;
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
    public class GetOrdenTrabajoByIdQueryHandler : IRequestHandler<GetOrdenTrabajoByIdQuery, GetOrdenTrabajoByIdDto?>
    {
        private readonly StoredDbContext _dbContext;

        public GetOrdenTrabajoByIdQueryHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetOrdenTrabajoByIdDto?> Handle(GetOrdenTrabajoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.OrdenTrabajo
                .Where(x => x.Id == request.id)
                .Select(x => new GetOrdenTrabajoByIdDto
                {
                    Id = x.Id,
                    Cantidad = x.Cantidad,
                    Estado = x.Estado,
                    RecetaNombre = x.Receta.Nombre,
                    Tipo = x.Tipo,
                    UsuarioCocineroNombre = x.UsuarioCocinero.Nombre,
                })
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
