using Catering.Application.Usuarios.GetUsuarios;
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
    public class GetUsuariosQueryHandler : IRequestHandler<GetUsuariosQuery, List<GetUsuariosDto>?>
    {
        private readonly StoredDbContext _dbContext;

        public GetUsuariosQueryHandler(StoredDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetUsuariosDto>?> Handle(GetUsuariosQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Usuario                
                .Select(x => new GetUsuariosDto
                {
                    Id = x.Id,
                    Nombre = x.Nombre                    
                })
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
