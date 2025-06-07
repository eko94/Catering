using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Contratos
{
    public record ContratoDiasRealizados
    {
        public int Value { get; set; }

        public ContratoDiasRealizados(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Días realizados debe ser mayor o igual 0", nameof(value));
            }
            Value = value;
        }

        public static implicit operator int(ContratoDiasRealizados cantidad)
        {
            return cantidad == null ? 0 : cantidad.Value;
        }

        public static implicit operator ContratoDiasRealizados(int a)
        {
            return new ContratoDiasRealizados(a);
        }
    }
}