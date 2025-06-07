using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
using Catering.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Repositories
{
    public class PlanAlimentarioRepository : IPlanAlimentarioRepository
    {
        private readonly DomainDbContext _dbContext;

        public PlanAlimentarioRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(PlanAlimentario entity)
        {
            await _dbContext.PlanAlimentario.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.PlanAlimentario.Remove(obj);
        }

        public async Task<PlanAlimentario?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.PlanAlimentario.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                var plan = await _dbContext.PlanAlimentario
                    .Include("_recetasList")
                    .SingleOrDefaultAsync(x => x.Id == id);
                return plan;
            }
        }


        public Task UpdateAsync(PlanAlimentario item)
        {
            _dbContext.PlanAlimentario.Update(item);

            return Task.CompletedTask;
        }
    }
}
