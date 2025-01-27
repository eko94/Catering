using Catering.Domain.Ingredientes;
using Catering.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Repositories
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly DomainDbContext _dbContext;

        public IngredienteRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Ingrediente entity)
        {
            await _dbContext.Ingrediente.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Ingrediente.Remove(obj);
        }

        public async Task<Ingrediente?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Ingrediente.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Ingrediente.FindAsync(id);
            }
        }


        public Task UpdateAsync(Ingrediente item)
        {
            _dbContext.Ingrediente.Update(item);

            return Task.CompletedTask;

        }
    }
}
