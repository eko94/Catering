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
    public class OrdenTrabajoFactory : IOrdenTrabajoFactory
    {
        public OrdenTrabajo CreateOrdenTrabajo(Guid idUsuarioCocinero, Guid idReceta, int cantidad, List<Guid> clientes)
        {
            if (idUsuarioCocinero == Guid.Empty)
            {
                throw new ArgumentException("Usuario cocinero no puede ser vacío", nameof(idUsuarioCocinero));
            }
            if (idReceta == Guid.Empty)
            {
                throw new ArgumentNullException("Receta no puede ser nulo", nameof(idReceta));
            }
            if (cantidad <= 0)
            {
                throw new ArgumentException("Cantidad debe ser mayor a 0", nameof(cantidad));
            }
            if (clientes.Count <= 0)
            {
                throw new ArgumentException("Lista de clientes debe ser mayor a 1", nameof(clientes));
            }
            if (cantidad != clientes.Count)
            {
                throw new ArgumentException("Cantidad no debe ser mayor a la lista de clientes", nameof(cantidad));
            }

            return new OrdenTrabajo(Guid.NewGuid(), idUsuarioCocinero, idReceta, cantidad, OrdenTrabajoType.Comida, clientes);
        }
    }
}
