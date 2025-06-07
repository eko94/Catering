using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo
{
    public record PlanAlimentarioRecetaDia
    {
        public int Value { get; set; }

        public PlanAlimentarioRecetaDia(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Día debe ser mayor a 0", nameof(value));
            }
            Value = value;
        }

        public static implicit operator int(PlanAlimentarioRecetaDia cantidad)
        {
            return cantidad == null ? 0 : cantidad.Value;
        }

        public static implicit operator PlanAlimentarioRecetaDia(int a)
        {
            return new PlanAlimentarioRecetaDia(a);
        }
    }
}
