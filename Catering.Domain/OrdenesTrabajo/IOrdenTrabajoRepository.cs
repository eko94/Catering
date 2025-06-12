using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo
{
    public interface IOrdenTrabajoRepository : IRepository<OrdenTrabajo>
    {
        Task UpdateAsync(OrdenTrabajo ordenTrabajo);
        Task DeleteAsync(Guid id);
        Task AddRangeAsync(List<OrdenTrabajo> ordenes);
    }
}
