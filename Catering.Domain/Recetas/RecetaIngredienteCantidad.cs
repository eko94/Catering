using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Recetas
{
    public record RecetaIngredienteCantidad
    {
        public double Value { get; set; }

        public RecetaIngredienteCantidad(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Cantidad debe ser mayor a 0", nameof(value));
            }
            Value = value;
        }

        public static implicit operator double(RecetaIngredienteCantidad cantidad)
        {
            return cantidad == null ? 0 : cantidad.Value;
        }

        public static implicit operator RecetaIngredienteCantidad(double a)
        {
            return new RecetaIngredienteCantidad(a);
        }
    }
}
