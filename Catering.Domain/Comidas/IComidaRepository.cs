using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Comidas
{
    public interface IComidaRepository : IRepository<Comida>
    {
        Task UpdateAsync(Comida comida);
        Task DeleteAsync(Guid id);
    }
}
