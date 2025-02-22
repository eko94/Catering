using Catering.Domain.Recetas;
using Catering.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Repositories
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly DomainDbContext _dbContext;

        public RecetaRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Receta entity)
        {
            await _dbContext.Receta.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Receta.Remove(obj);
        }

        public async Task<Receta?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Receta.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Receta
                    .Include("_instruccionesList")
                    .Include("_ingredientesList")
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
        }


        public Task UpdateAsync(Receta item)
        {
            _dbContext.Receta.Update(item);

            return Task.CompletedTask;

        }
    }
}
