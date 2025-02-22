using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo.Events;
using Catering.Domain.Recetas;
using Catering.Domain.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo
{
    public class OrdenTrabajo : AggregateRoot
    {
        public Guid IdUsuarioCocinero { get; private set; }
        public Guid IdReceta { get; private set; }
        public OrdenTrabajoCantidad Cantidad { get; private set; }
        public OrdenTrabajoStatus Estado { get; private set; }
        public OrdenTrabajoType Tipo { get; private set; }
        private List<Comida>? _comidasList { get; set; }
        public ICollection<Comida> Comidas { get { return _comidasList; } }
        private List<OrdenTrabajoCliente>? _clientesList { get; set; }
        public ICollection<OrdenTrabajoCliente> Clientes { get { return _clientesList; } }
        public DateTime FechaCreado { get; private set; }


        public OrdenTrabajo(Guid id, Guid idUsuarioCocinero, Guid idReceta, int cantidad, OrdenTrabajoType tipo, List<Guid> clientes) : base(id)
        {
            IdUsuarioCocinero = idUsuarioCocinero;
            IdReceta = idReceta;
            Cantidad = cantidad;
            Estado = OrdenTrabajoStatus.Creado;
            Tipo = tipo;
            _comidasList = new List<Comida>();
            _clientesList = clientes.Select(cliente => new OrdenTrabajoCliente(Id, cliente)).ToList();
            FechaCreado = DateTime.Now;
        }
        


        public void PrepararReceta()
        {
            if(Estado != OrdenTrabajoStatus.Creado)
            {
                throw new InvalidOperationException($"Solo se puede preparar la receta cuando el orden de trabajo de está en estado {nameof(OrdenTrabajoStatus.Creado)}");
            }

            Estado = OrdenTrabajoStatus.EnPreparacion;

            AddDomainEvent(new OrdenTrabajoEnPreparacionEvent(Id, IdReceta, Cantidad));
        }

        public void SetComidasPreparadas(List<Comida> comidas)
        {
            if (Estado != OrdenTrabajoStatus.EnPreparacion)
            {
                throw new Exception("La Orden de Trabajo solo se puede pasar a estado Preparado cuando esté en estado en Preparación.");
            }
            _comidasList = comidas;

            Estado = OrdenTrabajoStatus.Preparado;
        }

        public void EmpaquetarComidas()
        {
            if(Estado != OrdenTrabajoStatus.Preparado)
            {
                throw new InvalidOperationException($"Solo se puede preparar la receta cuando el orden de trabajo de está en estado {nameof(OrdenTrabajoStatus.Preparado)}");
            }
            if (_comidasList == null || _comidasList.Count <= 0)
            {
                throw new InvalidOperationException($"La orden de trabajo no cuenta con ninguna comida preparada");
            }

            foreach (var comida in _comidasList)
            {
                comida.Empaquetar();
            }

            Estado = OrdenTrabajoStatus.Empaquetado;
        }

        public void EtiquetarComidas()
        {
            if (Estado != OrdenTrabajoStatus.Empaquetado)
            {
                throw new InvalidOperationException($"Solo se puede preparar la receta cuando el orden de trabajo de está en estado {nameof(OrdenTrabajoStatus.Empaquetado)}");
            }
            if (_comidasList == null || _comidasList.Count <= 0)
            {
                throw new InvalidOperationException($"La orden de trabajo no cuenta con ninguna comida empaquetada");
            }

            for (var i = 0; i < _comidasList.Count; i++)
            {
                var comida = _comidasList[i];
                comida.Etiquetar(_clientesList[i].IdCliente);
            }

            Estado = OrdenTrabajoStatus.Finalizado;
        }

        public void CancelarOrden()
        {
            if (Estado == OrdenTrabajoStatus.Cancelado)
            {
                throw new InvalidOperationException($"El orden de trabajo ya se encuentra {nameof(OrdenTrabajoStatus.Cancelado)}");
            }
            if (Estado != OrdenTrabajoStatus.Creado)
            {
                throw new InvalidOperationException($"Solo se puede cancelar cuando el orden de trabajo de está en estado {nameof(OrdenTrabajoStatus.Creado)}");
            }       

            Estado = OrdenTrabajoStatus.Cancelado;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private OrdenTrabajo(){ }
    }
}
