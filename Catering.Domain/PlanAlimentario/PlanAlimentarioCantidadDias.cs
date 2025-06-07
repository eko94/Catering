using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo
{
    public record PlanAlimentarioCantidadDias
    {
        public int Value { get; set; }

        public PlanAlimentarioCantidadDias(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Cantidad debe ser mayor a 0", nameof(value));
            }
            Value = value;
        }

        public static implicit operator int(PlanAlimentarioCantidadDias cantidad)
        {
            return cantidad == null ? 0 : cantidad.Value;
        }

        public static implicit operator PlanAlimentarioCantidadDias(int a)
        {
            return new PlanAlimentarioCantidadDias(a);
        }
    }
}
