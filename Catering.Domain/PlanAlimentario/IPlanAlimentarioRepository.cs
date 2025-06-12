using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.PlanAlimentario
{
    public interface IPlanAlimentarioRepository : IRepository<PlanAlimentario>
    {
        Task UpdateAsync(PlanAlimentario planAlimentario);
        Task DeleteAsync(Guid id);

        Task AddReceta(PlanAlimentarioReceta planAlimentarioReceta);
    }
}