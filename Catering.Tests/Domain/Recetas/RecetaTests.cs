using Catering.Domain.Comidas;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Domain.Recetas
{
    public class RecetaTests
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
        public void CreacionRecetaEsInvalidoNombre()
        {
            // Arrange

            // Act
            Action act = () => new Receta(_idReceta, string.Empty);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateNombreEsValido()
        {
            // Arrange

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.UpdateNombre(_nombreReceta);

            // Assert
            Assert.Equal(_nombreReceta, receta.Nombre);
        }

        [Fact]
        public void UpdateNombreEsInvalido()
        {
            // Arrange

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            Action act = () => receta.UpdateNombre(string.Empty);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void AddIngredienteEsInvalidoIdIngrediente()
        {
            // Arrange

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            Action act = () => receta.AddIngrediente(Guid.Empty, string.Empty, 1);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void AddIngredienteEsInvalidoCantidad()
        {
            // Arrange

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            Action act = () => receta.AddIngrediente(Guid.NewGuid(), string.Empty, -1);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateIngredienteEsInvalidoIdIngrediente()
        {
            // Arrange
            Guid idIngrediente1 = Guid.NewGuid();

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddIngrediente(idIngrediente1, string.Empty, 1);
            Action act = () => receta.UpdateIngrediente(receta.Ingredientes.First().Id, Guid.Empty, string.Empty, 1);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void UpdateIngredienteEsInvalidoIdCantidad()
        {
            // Arrange
            Guid idIngrediente1 = Guid.NewGuid();

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddIngrediente(idIngrediente1, string.Empty, 1);
            Action act = () => receta.UpdateIngrediente(receta.Ingredientes.First().Id, idIngrediente1, string.Empty, -1);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateIngredienteEsInvalidoIdRecetaIngrediente()
        {
            // Arrange
            Guid idIngrediente1 = Guid.NewGuid();

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddIngrediente(idIngrediente1, string.Empty, 1);
            Action act = () => receta.UpdateIngrediente(Guid.NewGuid(), idIngrediente1, string.Empty, 1);

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void UpdateIngredienteEsValido()
        {
            // Arrange
            Guid idIngrediente1 = Guid.NewGuid();

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddIngrediente(idIngrediente1, string.Empty, 1);
            receta.UpdateIngrediente(receta.Ingredientes.First().Id, idIngrediente1, string.Empty, 1);

            // Assert
            Assert.Equal(receta.Ingredientes.First().IdIngrediente, idIngrediente1);
            Assert.Equal(receta.Ingredientes.First().Cantidad, 1);
        }

        [Fact]
        public void RemoveIngredienteEsInvalidoIdRecetaIngredienteVacio()
        {
            // Arrange
            Guid idIngrediente1 = Guid.NewGuid();

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddIngrediente(idIngrediente1, string.Empty, 1);
            Action act = () => receta.RemoveIngrediente(Guid.Empty);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void RemoveIngredienteEsInvalidoIdRecetaIngrediente()
        {
            // Arrange
            Guid idIngrediente1 = Guid.NewGuid();

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddIngrediente(idIngrediente1, string.Empty, 1);
            Action act = () => receta.RemoveIngrediente(Guid.NewGuid());

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void RemoveIngredienteEsValido()
        {
            // Arrange
            Guid idIngrediente1 = Guid.NewGuid();

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddIngrediente(idIngrediente1, string.Empty, 1);
            receta.RemoveIngrediente(receta.Ingredientes.First().Id);

            // Assert
            Assert.True(receta.Ingredientes.Count == 0);
        }

        [Fact]
        public void AddInstruccionEsInvalidoInstruccion()
        {
            // Arrange

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            Action act = () => receta.AddInstrucciones(string.Empty);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void AddInstruccionEsValido()
        {
            // Arrange
            string instruccion1 = "Instruccion 1";

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddInstrucciones(instruccion1);

            // Assert
            Assert.True(receta.Instrucciones.Count == 1);
            Assert.True(receta.Instrucciones.First().Instruccion == instruccion1);
        }


        [Fact]
        public void UpdateInstruccionEsInvalidoIdInstruccion()
        {
            // Arrange
            string instruccion1 = "Instruccion 1";

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddInstrucciones(instruccion1);
            Action act = () => receta.UpdateInstruccion(Guid.Empty, instruccion1);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateInstruccionEsInvalidoInstruccion()
        {
            // Arrange
            string instruccion1 = "Instruccion 1";

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddInstrucciones(instruccion1);
            Action act = () => receta.UpdateInstruccion(receta.Instrucciones.First().Id, string.Empty);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void UpdateInstruccionEsInvalidoIdInstruccionNoValido()
        {
            // Arrange
            string instruccion1 = "Instruccion 1";

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddInstrucciones(instruccion1);
            Action act = () => receta.UpdateInstruccion(Guid.NewGuid(), instruccion1);

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void UpdateInstruccionEsValido()
        {
            // Arrange
            string instruccion1 = "Instruccion 1";

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddInstrucciones(instruccion1);
            receta.UpdateInstruccion(receta.Instrucciones.First().Id, instruccion1);

            // Assert
            Assert.Equal(receta.Instrucciones.First().Instruccion, instruccion1);
        }

        [Fact]
        public void RemoveInstruccionEsInvalidoIdInstruccion()
        {
            // Arrange
            string instruccion1 = "Instruccion 1";

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddInstrucciones(instruccion1);
            Action act = () => receta.RemoveInstruccion(Guid.Empty);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void RemoveInstruccionEsInvalidoIdInstruccionNoValido()
        {
            // Arrange
            string instruccion1 = "Instruccion 1";

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddInstrucciones(instruccion1);
            Action act = () => receta.RemoveInstruccion(Guid.NewGuid());

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void RemoveInstruccionEsValido()
        {
            // Arrange
            string instruccion1 = "Instruccion 1";

            // Act
            var receta = new Receta(_idReceta, _nombreReceta);
            receta.AddInstrucciones(instruccion1);
            receta.RemoveInstruccion(receta.Instrucciones.First().Id);

            // Assert
            Assert.True(receta.Instrucciones.Count == 0);
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
            var comida = new ComidaFactory().CreateComida(_nombreReceta, idOrdenTrabajo);
            comida.Preparar(receta.Ingredientes.ToList());

            // Assert
            Assert.Equal(_nombreReceta, receta.Nombre);
            Assert.Equal(_nombreReceta, comida.Nombre);
            Assert.Equal(idOrdenTrabajo, comida.IdOrdenTrabajo);
            Assert.Equal(ComidaStatus.Preparado, comida.Estado);
        }
    }
}
