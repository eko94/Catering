using Catering.Domain.Abstractions;
using Catering.Domain.Contratos;
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
    public class ContratoRepository : IContratoRepository
    {
        private readonly DomainDbContext _dbContext;

        public ContratoRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Contrato entity)
        {
            await _dbContext.Contrato.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Contrato.Remove(obj);
        }

        public async Task<Contrato?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Contrato.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                try
                {
                    var plan = await _dbContext.Contrato
                    .Include("_entregasCanceladasList")
                    .SingleOrDefaultAsync(x => x.Id == id);
                    return plan;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }


        public Task UpdateAsync(Contrato item)
        {
            _dbContext.Contrato.Update(item);

            return Task.CompletedTask;
        }

        public async Task AddEntregaCancelada(ContratoEntregaCancelada entity)
        {
            await _dbContext.ContratoEntregaCancelada.AddAsync(entity);
        }
    }
}
