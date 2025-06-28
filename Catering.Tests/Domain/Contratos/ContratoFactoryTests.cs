using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.Contratos;
using Catering.Domain.Ingredientes;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;

namespace Catering.Tests.Domain.Comidas
{
    public class ContratoFactoryTests
    {
        private Guid _idContrato = Guid.NewGuid();
        private Guid _idCliente = Guid.NewGuid();
        private Guid _idPlanAlimentario = Guid.NewGuid();
        private int _diasContratados = 15;
        private DateTime _fechaInicio = DateTime.Today;

        private readonly IContratoFactory _contratoFactory;

        public ContratoFactoryTests()
        {
            _contratoFactory = new ContratoFactory();
        }

        [Fact]
        public void CreacionContratoEsValido()
        {
            // Arrange            

            // Act
            var contrato = _contratoFactory.CreateContrato(_idContrato, _idCliente, _idPlanAlimentario, _diasContratados, _fechaInicio);

            // Assert
            Assert.Equal(_idContrato, contrato.Id);
            Assert.Equal(_idCliente, contrato.IdCliente);
            Assert.Equal(_idPlanAlimentario, contrato.IdPlanAlimentario);
            Assert.Equal(_diasContratados, (int)contrato.DiasContratados);
            Assert.Equal(_fechaInicio, contrato.FechaInicio);
        }

        [Fact]
        public void CreacionContratoEsInvalidoIdContrato()
        {
            // Arrange            

            // Act
            var act = () => _contratoFactory.CreateContrato(Guid.Empty, _idCliente, _idPlanAlimentario, _diasContratados, _fechaInicio);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }       

        [Fact]
        public void CreacionContratoEsInvalidoIdCliente()
        {
            // Arrange            

            // Act
            var act = () => _contratoFactory.CreateContrato(_idContrato, Guid.Empty, _idPlanAlimentario, _diasContratados, _fechaInicio);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }       

        [Fact]
        public void CreacionContratoEsInvalidoIdPlanAlimentario()
        {
            // Arrange            

            // Act
            var act = () => _contratoFactory.CreateContrato(_idContrato, _idCliente, Guid.Empty, _diasContratados, _fechaInicio);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }       

        [Fact]
        public void CreacionContratoEsInvalido()
        {
            // Arrange            

            // Act
            var act = () => _contratoFactory.CreateContrato(_idContrato, _idCliente, _idPlanAlimentario, 0, _fechaInicio);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }       
    }
}
