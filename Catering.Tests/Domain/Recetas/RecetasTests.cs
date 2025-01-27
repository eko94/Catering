using Catering.Domain.Comidas;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Domain.Recetas
{
    public class RecetasTests
    {
        private Guid _idReceta = Guid.NewGuid();
        private string _nombreReceta = "Receta de prueba";

        [Fact]
        public void CreacionRecetaEsValido()
        {
            // Arrange

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);

            // Assert
            Assert.Equal(_nombreReceta, receta.Nombre);
        }

        [Fact]
        public void PrepararRecetaEsValido()
        {
            // Arrange
            Guid idOrdenTrabajo = Guid.NewGuid();
            Guid idIngrediente1 = Guid.NewGuid();
            string detalleIngrediente1 = "Detalle";
            int cantidadIngrediente1 = 1;

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddIngrediente(idIngrediente1, detalleIngrediente1, cantidadIngrediente1);
            var comida = receta.PrepararReceta(idOrdenTrabajo);

            // Assert
            Assert.Equal(_nombreReceta, receta.Nombre);
            Assert.Equal(_nombreReceta, comida.Nombre);
            Assert.Equal(idOrdenTrabajo, comida.IdOrdenTrabajo);
            Assert.Equal(ComidaStatus.Preparado, comida.Estado);
        }
    }
}
