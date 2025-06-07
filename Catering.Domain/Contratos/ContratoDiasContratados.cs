using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Contratos
{
    public record ContratoDiasContratados
    {
        public int Value { get; set; }

        public ContratoDiasContratados(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Días contratados debe ser mayor a 0", nameof(value));
            }
            Value = value;
        }

        public static implicit operator int(ContratoDiasContratados cantidad)
        {
            return cantidad == null ? 0 : cantidad.Value;
        }

        public static implicit operator ContratoDiasContratados(int a)
        {
            return new ContratoDiasContratados(a);
        }
    }
}