using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Recetas
{
    public record RecetaIngredienteCantidad
    {
        public float Value { get; set; }

        public RecetaIngredienteCantidad(float value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Cantidad debe ser mayor a 0", nameof(value));
            }
            Value = value;
        }

        public static implicit operator float(RecetaIngredienteCantidad cantidad)
        {
            return cantidad == null ? 0 : cantidad.Value;
        }

        public static implicit operator RecetaIngredienteCantidad(float a)
        {
            return new RecetaIngredienteCantidad(a);
        }
    }
}
