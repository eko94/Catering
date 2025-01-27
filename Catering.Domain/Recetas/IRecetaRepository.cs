using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Recetas
{
    public interface IRecetaRepository : IRepository<Receta>
    {
        Task UpdateAsync(Receta ordenTrabajo);
        Task DeleteAsync(Guid id);
    }
}
