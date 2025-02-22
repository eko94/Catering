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
    public class RecetaIngredienteTests
    {
        private Guid _idReceta = Guid.NewGuid();
        private Guid _idIngrediente = Guid.NewGuid();
        private string _detalle = "Detalle 1";
        private float _cantidad = 1;

        [Fact]
        public void CreacionRecetaIngredienteEsValido()
        {
            // Arrange

            // Act
            var receta = new RecetaIngrediente(_idReceta, _idIngrediente, _detalle, _cantidad);

            // Assert
            Assert.Equal(_idReceta, receta.IdReceta);
            Assert.Equal(_idIngrediente, receta.IdIngrediente);
            Assert.Equal(_detalle, receta.Detalle);
            Assert.Equal(_cantidad, (float)receta.Cantidad);
        }

        [Fact]
        public void UpdateRecetaIngredienteEsInvalidoIdIngrediente()
        {
            // Arrange

            // Act
            var receta = new RecetaIngrediente(_idReceta, _idIngrediente, _detalle, _cantidad);
            Action act = () => receta.Update(Guid.Empty, _detalle, _cantidad);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateRecetaIngredienteEsInvalidoCantidad()
        {
            // Arrange

            // Act
            var receta = new RecetaIngrediente(_idReceta, _idIngrediente, _detalle, _cantidad);
            Action act = () => receta.Update(_idIngrediente, _detalle, -1);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
