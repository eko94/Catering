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
    public class RecetaInstruccionTests
    {
        private Guid _idReceta = Guid.NewGuid();
        private string _instruccion = "Instruccion 1";

        [Fact]
        public void CreacionRecetaInstruccionEsValido()
        {
            // Arrange

            // Act
            var instruccion = new RecetaInstruccion(_idReceta, _instruccion);

            // Assert
            Assert.Equal(_idReceta, instruccion.IdReceta);
            Assert.Equal(_instruccion, instruccion.Instruccion);
        }

        [Fact]
        public void UpdateRecetaIngredienteCantidadEsInvalido()
        {
            // Arrange

            // Act
            var instruccion = new RecetaInstruccion(_idReceta, _instruccion);
            Action act = () => instruccion.Update(string.Empty);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }
    }
}
