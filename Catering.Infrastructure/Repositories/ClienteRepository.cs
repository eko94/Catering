using Catering.Domain.Clientes;
using Catering.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DomainDbContext _dbContext;

        public ClienteRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Cliente entity)
        {
            await _dbContext.Cliente.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Cliente.Remove(obj);
        }

        public async Task<Cliente?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Cliente.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Cliente.FindAsync(id);
            }
        }


        public Task UpdateAsync(Cliente item)
        {
            _dbContext.Cliente.Update(item);

            return Task.CompletedTask;

        }
    }
}
