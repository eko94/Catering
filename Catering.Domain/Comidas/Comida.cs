﻿using Catering.Domain.Abstractions;
using Catering.Domain.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Comidas
{
    public class Comida : AggregateRoot
    {
        public string Nombre { get; private set; }
        public ComidaStatus Estado { get; private set; }
        public Guid IdCliente { get; private set; }
        public Guid IdOrdenTrabajo { get; private set; }

        public Comida(string nombre, Guid idOrdenTrabajo) : base(Guid.NewGuid())
        {
            Nombre = nombre;
            Estado = ComidaStatus.PorPreparar;
            IdCliente = Guid.Empty;
            IdOrdenTrabajo = idOrdenTrabajo;
        }

        public void Preparar(List<Recetas.RecetaIngrediente> ingredientes)
        {
            if (Estado != ComidaStatus.PorPreparar)
            {
                throw new InvalidOperationException("Solo se puede preparar una comida que esté por preparar.");
            }
            Estado = ComidaStatus.EnPreparacion;
            Task.Delay(500);
            Estado = ComidaStatus.Preparado;
        }

        public void Empaquetar()
        {
            if(Estado != ComidaStatus.Preparado)
            {
                throw new InvalidOperationException("Solo se puede empaquetar una comida que esté preparada.");
            }
            Estado = ComidaStatus.Empaquetado;
        }

        public void Etiquetar(Guid idCliente)
        {
            if (Estado != ComidaStatus.Empaquetado)
            {
                throw new InvalidOperationException("Solo se puede etiquetar una comida que esté empaquetada.");
            }
            if(idCliente == null)
            {
                throw new InvalidOperationException("No se puede etiquetar una comida con un cliente nulo.");
            }

            IdCliente = idCliente;

            Estado = ComidaStatus.Etiquetado;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private Comida() { }
    }
}
