using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.Recetas;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Catering.Tests.Domain.Comidas
{
    public class IngredientesTests
    {
        private Guid _id = Guid.NewGuid();
        string _nombre = "Ingrediente 1";
        string _medicion = "Medicion 1";
        string _tipo = "Tipo 1";

        [Fact]
        public void CreacionIngredienteEsValido()
        {
            // Arrange            

            // Act
            var ingrediente = new Ingrediente(_id, _nombre, _medicion, _tipo);

            // Assert
            Assert.Equal(_id, ingrediente.Id);
            Assert.Equal(_nombre, ingrediente.Nombre);
            Assert.Equal(_medicion, ingrediente.Medicion);
            Assert.Equal(_tipo, ingrediente.Tipo);
        }

        [Fact]
        public void ActualizarIngrediente()
        {
            // Arrange            
            var ingrediente = new Ingrediente(_id, _nombre, _medicion, _tipo);

            // Act
            ingrediente.UpdateIngrediente(_nombre, _medicion, _tipo, 0, 0);

            // Assert
            Assert.Equal(_id, ingrediente.Id);
            Assert.Equal(_nombre, ingrediente.Nombre);
            Assert.Equal(_medicion, ingrediente.Medicion);
            Assert.Equal(_tipo, ingrediente.Tipo);
        }       

        [Fact]
        public void ActualizarIngredienteSinNombre()
        {
            // Arrange            
            var ingrediente = new Ingrediente(_id, _nombre, _medicion, _tipo);

            // Act
            Action act = () => ingrediente.UpdateIngrediente(string.Empty, _medicion, _tipo, 0, 0);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void ActualizarIngredienteSinMedicion()
        {
            // Arrange            
            var ingrediente = new Ingrediente(_id, _nombre, _medicion, _tipo);

            // Act
            Action act = () => ingrediente.UpdateIngrediente(_nombre, string.Empty, _tipo, 0, 0);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void ActualizarIngredienteSinTipo()
        {
            // Arrange            
            var ingrediente = new Ingrediente(_id, _nombre, _medicion, _tipo);

            // Act
            Action act = () => ingrediente.UpdateIngrediente(_nombre, _medicion, string.Empty, 0, 0);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void ActualizarIngredienteSinCostoCompra()
        {
            // Arrange            
            var ingrediente = new Ingrediente(_id, _nombre, _medicion, _tipo);

            // Act
            Action act = () => ingrediente.UpdateIngrediente(_nombre, _medicion, _tipo, -1, 0);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void ActualizarIngredienteSinCostoVenta()
        {
            // Arrange            
            var ingrediente = new Ingrediente(_id, _nombre, _medicion, _tipo);

            // Act
            Action act = () => ingrediente.UpdateIngrediente(_nombre, _medicion, _tipo, 0, -1);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
