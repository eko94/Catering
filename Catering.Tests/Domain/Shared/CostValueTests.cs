using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.Recetas;
using Catering.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Domain.Recetas
{
    public class CostValueTests
    {
        private decimal _value = 1;

        [Fact]
        public void CreacionCostValueEsValido()
        {
            // Arrange

            // Act
            var instruccion = new CostValue(_value);

            // Assert
            Assert.Equal(_value, (decimal)instruccion);
        }

        [Fact]
        public void CreacionCostValueEsInvalido()
        {
            // Arrange

            // Act
            Action act = () => new CostValue(-1);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ToStringEsValido()
        {
            // Arrange

            // Act
            var instruccion = new CostValue(_value);

            // Assert
            Assert.StartsWith("Bs.", instruccion.ToString());
        }
    }
}
