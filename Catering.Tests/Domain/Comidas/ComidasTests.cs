using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.Recetas;

namespace Catering.Tests.Domain.Comidas
{
    public class ComidasTests
    {
        Guid _idComida = Guid.NewGuid();
        private string _nombre = "Comida 1";
        private Guid _idOrdenTrabajo = Guid.NewGuid();
        private Guid _idReceta = Guid.NewGuid();
        private Guid _ingrediente1 = Guid.NewGuid();
        private int _ingredientes1Cantidad = 1;
        private Guid _ingrediente2 = Guid.NewGuid();
        private int _ingredientes2Cantidad = 2;
        private Guid _ingrediente3 = Guid.NewGuid();
        private int _ingredientes3Cantidad = 1;        
        private Guid _idCliente = Guid.NewGuid();

        [Fact]
        public void CreacionComidaEsValido()
        {
            // Arrange            

            // Act
            var comida = new Comida(_idComida, _nombre, _idOrdenTrabajo);

            // Assert
            Assert.Equal(_idComida, comida.Id);
            Assert.Equal(_nombre, comida.Nombre);
            Assert.Equal(ComidaStatus.PorPreparar, comida.Estado);
            Assert.Equal(null, comida.IdCliente);
            Assert.Equal(_idOrdenTrabajo, comida.IdOrdenTrabajo);
        }

        [Fact]
        public void PrepararComidaEsValido()
        {
            // Arrange
            List<RecetaIngrediente> ingredientes = new List<RecetaIngrediente>
            {
                new RecetaIngrediente(_idReceta, _ingrediente1, "", _ingredientes1Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente2, "", _ingredientes2Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente3, "", _ingredientes3Cantidad)
            };

            // Act
            var comida = new Comida(_idComida, _nombre, _idOrdenTrabajo);
            comida.Preparar(ingredientes);

            // Assert
            Assert.Equal(_idComida, comida.Id);
            Assert.Equal(_nombre, comida.Nombre);
            Assert.Equal(ComidaStatus.Preparado, comida.Estado);
            Assert.Equal(null, comida.IdCliente);
            Assert.Equal(_idOrdenTrabajo, comida.IdOrdenTrabajo);
        }

        [Fact]
        public void EmpaquetarComidaEsValido()
        {
            // Arrange
            List<RecetaIngrediente> ingredientes = new List<RecetaIngrediente>
            {
                new RecetaIngrediente(_idReceta, _ingrediente1, "", _ingredientes1Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente2, "", _ingredientes2Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente3, "", _ingredientes3Cantidad)
            };

            // Act
            var comida = new Comida(_idComida, _nombre, _idOrdenTrabajo);
            comida.Preparar(ingredientes);
            comida.Empaquetar();

            // Assert
            Assert.Equal(_idComida, comida.Id);
            Assert.Equal(_nombre, comida.Nombre);
            Assert.Equal(ComidaStatus.Empaquetado, comida.Estado);
            Assert.Equal(null, comida.IdCliente);
            Assert.Equal(_idOrdenTrabajo, comida.IdOrdenTrabajo);
        }

        [Fact]
        public void EmpaquetarComidaEsInvalido()
        {
            // Arrange
            List<RecetaIngrediente> ingredientes = new List<RecetaIngrediente>
            {
                new RecetaIngrediente(_idReceta, _ingrediente1, "", _ingredientes1Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente2, "", _ingredientes2Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente3, "", _ingredientes3Cantidad)
            };

            // Act
            var comida = new Comida(_idComida, _nombre, _idOrdenTrabajo);
            Action act = () => comida.Empaquetar();

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }

        [Fact]
        public void EtiquetarComidaEsValido()
        {
            // Arrange
            List<RecetaIngrediente> ingredientes = new List<RecetaIngrediente>
            {
                new RecetaIngrediente(_idReceta, _ingrediente1, "", _ingredientes1Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente2, "", _ingredientes2Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente3, "", _ingredientes3Cantidad)
            };

            // Act
            var comida = new Comida(_idComida, _nombre, _idOrdenTrabajo);
            comida.Preparar(ingredientes);
            comida.Empaquetar();
            comida.Etiquetar(_idCliente);

            // Assert
            Assert.Equal(_idComida, comida.Id);
            Assert.Equal(_nombre, comida.Nombre);
            Assert.Equal(ComidaStatus.Etiquetado, comida.Estado);
            Assert.Equal(_idCliente, comida.IdCliente);
            Assert.Equal(_idOrdenTrabajo, comida.IdOrdenTrabajo);
        }

        [Fact]
        public void EtiquetarComidaEsInvalido()
        {
            // Arrange
            List<RecetaIngrediente> ingredientes = new List<RecetaIngrediente>
            {
                new RecetaIngrediente(_idReceta, _ingrediente1, "", _ingredientes1Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente2, "", _ingredientes2Cantidad),
                new RecetaIngrediente(_idReceta, _ingrediente3, "", _ingredientes3Cantidad)
            };

            // Act
            var comida = new Comida(_idComida, _nombre, _idOrdenTrabajo);
            comida.Preparar(ingredientes);
            Action act = () => comida.Etiquetar(_idCliente);

            // Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
