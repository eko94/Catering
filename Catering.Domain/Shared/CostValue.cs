using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Shared
{
    public record CostValue
    {
        public decimal Value { get; init; }

        public CostValue(decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Costo no puede ser negativo", nameof(value));
            }            
            Value = value;
        }

        public static implicit operator decimal(CostValue value)
        {
            return value == null ? 0 : value.Value;
        }

        public static implicit operator CostValue(decimal value)
        {
            return new CostValue(value);
        }

        public override string ToString()
        {
            return $"Bs. {Value.ToString("F")}";
        }
    }
}
