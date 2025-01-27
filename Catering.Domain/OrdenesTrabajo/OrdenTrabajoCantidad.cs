using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo
{
    public record OrdenTrabajoCantidad
    {
        public int Value { get; set; }

        public OrdenTrabajoCantidad(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Cantidad debe ser mayor a 0", nameof(value));
            }
            Value = value;
        }

        public static implicit operator int(OrdenTrabajoCantidad cantidad)
        {
            return cantidad == null ? 0 : cantidad.Value;
        }

        public static implicit operator OrdenTrabajoCantidad(int a)
        {
            return new OrdenTrabajoCantidad(a);
        }
    }
}
