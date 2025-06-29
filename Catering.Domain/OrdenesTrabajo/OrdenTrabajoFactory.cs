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
        public OrdenTrabajo CreateOrdenTrabajo(Guid idUsuarioCocinero, Guid idReceta, int cantidad, List<OrdenTrabajoCliente> clientes)
        {
            if (idUsuarioCocinero == Guid.Empty)
            {
                throw new ArgumentException("Usuario cocinero no puede ser vacío", nameof(idUsuarioCocinero));
            }
            if (idReceta == Guid.Empty)
            {
                throw new ArgumentException("Receta no puede ser vacío", nameof(idReceta));
            }
            if (cantidad <= 0)
            {
                throw new ArgumentException("Cantidad debe ser mayor a 0", nameof(cantidad));
            }
            if (clientes == null || clientes.Count <= 0)
            {
                throw new ArgumentException("Lista de clientes debe ser mayor a 1", nameof(clientes));
            }
            if (cantidad != clientes.Count)
            {
                throw new ArgumentException("Cantidad no debe ser mayor a la lista de clientes", nameof(cantidad));
            }
            foreach(var cliente in clientes)
            {
                if (cliente.IdOrdenTrabajo != Guid.Empty)
                {
                    throw new ArgumentException("Orden Trabajo debe ser vacío", nameof(cliente.IdOrdenTrabajo));
                }
                if (cliente.IdCliente == Guid.Empty)
                {
                    throw new ArgumentException("Cliente no puede ser vacío", nameof(cliente.IdCliente));
                }
                if (cliente.IdContrato == Guid.Empty)
                {
                    throw new ArgumentException("Contrato no puede ser vacío", nameof(cliente.IdContrato));
                }
            }

            return new OrdenTrabajo(Guid.NewGuid(), idUsuarioCocinero, idReceta, cantidad, OrdenTrabajoType.Comida, clientes);
        }

        public OrdenTrabajoCliente CreateOrdenTrabajoCliente(Guid idCliente, Guid idContrato)
        {
            if (idCliente == Guid.Empty)
            {
                throw new ArgumentException("Cliente no puede ser vacío", nameof(idCliente));
            }
            if (idContrato == Guid.Empty)
            {
                throw new ArgumentException("Contrato no puede ser vacío", nameof(idContrato));
            }

            return new OrdenTrabajoCliente(Guid.Empty, idCliente, idContrato);
        }
    }
}
