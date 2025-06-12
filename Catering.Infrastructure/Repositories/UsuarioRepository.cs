using Catering.Domain.Usuarios;
using Catering.Infrastructure.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DomainDbContext _dbContext;

        public UsuarioRepository(DomainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Usuario entity)
        {
            await _dbContext.Usuario.AddAsync(entity);

        }

        public async Task DeleteAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            _dbContext.Usuario.Remove(obj);
        }

        public async Task<Usuario?> GetByIdAsync(Guid id, bool readOnly = false)
        {
            if (readOnly)
            {
                return await _dbContext.Usuario.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            else
            {
                return await _dbContext.Usuario.FindAsync(id);
            }
        }

        public Task UpdateAsync(Usuario item)
        {
            _dbContext.Usuario.Update(item);

            return Task.CompletedTask;

        }

        public async Task<Guid> GetRandomIdCocinero()
        {
            return await _dbContext.Usuario.Select(x => x.Id)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();
        }
    }
}
