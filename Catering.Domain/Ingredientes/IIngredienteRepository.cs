using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Ingredientes
{
    public interface IIngredienteRepository : IRepository<Ingrediente>
    {
        Task UpdateAsync(Ingrediente comida);
        Task DeleteAsync(Guid id);
    }
}
