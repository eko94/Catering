using Catering.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Recetas
{
    public class RecetaIngrediente : Entity
    {
        public Guid IdReceta { get; private set; }
        public Guid IdIngrediente { get; private set; }
        public string Detalle { get; private set; }
        public RecetaIngredienteCantidad Cantidad { get; private set; }

        public RecetaIngrediente(Guid idReceta, Guid idIngrediente, string detalle, float cantidad) : base(Guid.NewGuid())
        {
            IdReceta = idReceta;
            IdIngrediente = idIngrediente;
            Detalle = detalle;
            Cantidad = cantidad;
        }

        public void Update(Guid idIngrediente, string detalle, float cantidad)
        {
            if (idIngrediente == Guid.Empty)
            {
                throw new ArgumentNullException("Ingrediente no puede ser vacío");
            }
            if (string.IsNullOrEmpty(detalle))
            {
                throw new ArgumentNullException("Detalle no puede ser nulo");
            }
            if (cantidad <= 0)
            {
                throw new ArgumentException("Cantidad no puede ser menor o igual a 0");
            }

            IdIngrediente = idIngrediente;
            Cantidad = cantidad;
            Detalle = detalle;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private RecetaIngrediente() { }
    }
}
