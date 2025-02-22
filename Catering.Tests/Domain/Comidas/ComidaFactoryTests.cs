using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.Recetas;

namespace Catering.Tests.Domain.Comidas
{
    public class ComidaFactoryTests
    {
        private string _nombre = "Comida 1";
        private Guid _idOrdenTrabajo = Guid.NewGuid();

        private readonly IComidaFactory _comidaFactory;

        public ComidaFactoryTests()
        {
            _comidaFactory = new ComidaFactory();
        }

        [Fact]
        public void CreacionComidaEsValido()
        {
            // Arrange            

            // Act
            var comida = _comidaFactory.CreateComida(_nombre, _idOrdenTrabajo);

            // Assert
            Assert.Equal(_nombre, comida.Nombre);
            Assert.Equal(ComidaStatus.PorPreparar, comida.Estado);
            Assert.Equal(null, comida.IdCliente);
            Assert.Equal(_idOrdenTrabajo, comida.IdOrdenTrabajo);
        }

        [Fact]
        public void CreacionComidaEsInvalido()
        {
            // Arrange            

            // Act
            Action act = () => _comidaFactory.CreateComida(string.Empty, _idOrdenTrabajo);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }       
    }
}
