using Catering.Domain.Comidas;
using Catering.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Repositories
{
    public class ComidaRepository : IComidaRepository
    {
        private readonly DomainDbContext _dbContext;

        public ComidaRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Comida entity)
        {
            await _dbContext.Comida.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Comida.Remove(obj);
        }

        public async Task<Comida?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Comida.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Comida.FindAsync(id);
            }
        }


        public Task UpdateAsync(Comida item)
        {
            _dbContext.Comida.Update(item);

            return Task.CompletedTask;

        }
    }
}
