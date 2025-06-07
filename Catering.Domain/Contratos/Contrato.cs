using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Contratos
{
    public class Contrato : AggregateRoot
    {
        public Guid IdCliente { get; private set; }
        public Guid IdPlanAlimentario { get; private set; }
        public ContratoDiasContratados DiasContratados { get; private set; }
        public ContratoDiasRealizados DiasRealizados { get; private set; }
        public ContratoStatus Estado { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime? FechaUltimoRealizado { get; private set; }
        private List<ContratoEntregaCancelada>? _entregasCanceladasList { get; set; }
        public ICollection<ContratoEntregaCancelada> EntregasCanceladas { get { return _entregasCanceladasList; } }

        public Contrato(Guid id, Guid idCliente, Guid idPlanAlimentario, int diasContratados, DateTime fechaInicio) : base(id)
        {
            IdCliente = idCliente;
            IdPlanAlimentario = idPlanAlimentario;
            DiasContratados = diasContratados;
            DiasRealizados = 0;
            Estado = ContratoStatus.Iniciado;
            FechaInicio = fechaInicio;
            FechaUltimoRealizado = null;
            _entregasCanceladasList = new List<ContratoEntregaCancelada>();
        }

        #region EntregaCancelada
        public void AddEntregaCancelada(DateTime fechaCancelada)
        {
            if (fechaCancelada < DateTime.Today)
            {
                throw new ArgumentException("Fecha Cancelada no puede ser menor a la fecha actual", nameof(fechaCancelada));
            }

            ContratoEntregaCancelada ContratoEntregaCancelada = new ContratoEntregaCancelada(Id, fechaCancelada);
            _entregasCanceladasList.Add(ContratoEntregaCancelada);
        }

        public void RemoveContratoEntregaCancelada(DateTime fechaCancelada)
        {
            ContratoEntregaCancelada EntregaCancelada = _entregasCanceladasList.FirstOrDefault(x => x.FechaCancelada == fechaCancelada);
            if (EntregaCancelada == null)
            {
                throw new InvalidOperationException("Ingrediente no encontrado en la receta");
            }
            _entregasCanceladasList.Remove(EntregaCancelada);
        }
        #endregion EntregaCancelada

        /// <summary>
        /// Needed for EF
        /// </summary>
        private Contrato() { }
    }
}
