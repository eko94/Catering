using Catering.Domain.OrdenesTrabajo;
using Catering.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Repositories
{
    public class OrdenTrabajoRepository : IOrdenTrabajoRepository
    {
        private readonly DomainDbContext _dbContext;

        public OrdenTrabajoRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(OrdenTrabajo entity)
        {
            await _dbContext.OrdenTrabajo.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.OrdenTrabajo.Remove(obj);
        }

        public async Task<OrdenTrabajo?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.OrdenTrabajo.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.OrdenTrabajo.FindAsync(id);
            }
        }


        public Task UpdateAsync(OrdenTrabajo item)
        {
            _dbContext.OrdenTrabajo.Update(item);

            return Task.CompletedTask;

        }
    }
}
