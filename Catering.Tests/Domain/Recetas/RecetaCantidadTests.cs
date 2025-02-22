using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Domain.Recetas
{
    public class RecetaIngredienteCantidadTests
    {
        private float _cantidad = 1;

        [Fact]
        public void CreacionRecetaIngredienteCantidadEsValido()
        {
            // Arrange

            // Act
            var cantidad = new RecetaIngredienteCantidad(_cantidad);

            // Assert
            Assert.Equal(_cantidad, (float)cantidad);
        }

        [Fact]
        public void CreacionRecetaIngredienteCantidadEsInvalido()
        {
            // Arrange

            // Act
            Action act = () => new RecetaIngredienteCantidad(-1);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
