using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task UpdateAsync(Usuario Usuario);
        Task DeleteAsync(Guid id);
    }
}
