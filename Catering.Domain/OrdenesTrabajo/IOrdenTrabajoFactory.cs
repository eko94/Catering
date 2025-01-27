using Catering.Domain.Clientes;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo
{
    public interface IOrdenTrabajoFactory
    {
        OrdenTrabajo CreateOrdenTrabajo(Guid idUsuarioCocinero, Guid idReceta, int cantidad, List<Guid> clientes);
    }
}
