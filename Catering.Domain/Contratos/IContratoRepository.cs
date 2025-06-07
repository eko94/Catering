using Catering.Domain.Abstractions;
using Catering.Domain.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Contratos
{
    public interface IContratoRepository : IRepository<Contrato>
    {
        Task UpdateAsync(Contrato planAlimentario);
        Task DeleteAsync(Guid id);

        Task AddEntregaCancelada(ContratoEntregaCancelada entregaCancelada);
    }
}