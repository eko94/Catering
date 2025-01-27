using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Clientes
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task UpdateAsync(Cliente Cliente);
        Task DeleteAsync(Guid id);
    }
}
