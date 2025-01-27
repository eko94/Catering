using Catering.Domain.Abstractions;
using Catering.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Ingredientes
{
    public class Ingrediente : AggregateRoot
    {
        public string Nombre { get; private set; }
        public string Medicion { get; private set; }
        public string Tipo { get; private set; }
        public CostValue CostoCompra { get; private set; }
        public CostValue CostoVenta { get; private set; }

        public Ingrediente(string nombre, string medicion, string tipo) :base(Guid.NewGuid()) 
        {
            Nombre = nombre;
            Medicion = medicion;
            Tipo = tipo;
            CostoCompra = 0;
            CostoVenta = 0;
        }

        public void UpdateIngrediente(string nombre, string medicion, string tipo, decimal costoCompra, decimal costoVenta)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentNullException("Nombre no puede ser nulo", nameof(nombre));
            }
            if (!string.IsNullOrEmpty(medicion))
            {
                throw new ArgumentNullException("Medición no puede ser nulo", nameof(medicion));
            }
            if (!string.IsNullOrEmpty(tipo))
            {
                throw new ArgumentNullException("Tipo no puede ser nulo", nameof(tipo));
            }
            if (costoCompra < 0)
            {
                throw new ArgumentException("Costo compra no debe ser menor a 0", nameof(CostoCompra));
            }                
            if (costoVenta < 0)
            {
                throw new ArgumentException("Costo venta no debe ser menor a 0", nameof(CostoVenta));
            }                

            Nombre = nombre;
            Medicion = medicion;
            Tipo = tipo;
            CostoCompra = costoCompra;
            CostoVenta = costoVenta;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private Ingrediente() { }
    }
}
