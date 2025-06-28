using Catering.Domain.Clientes;
using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.PlanAlimentario;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Catering.Tests.Domain.PlanesAlimentarios
{
    public class PlanAlimentarioFactoryTests
    {
        private Guid _idPlanAlimentario = Guid.NewGuid();
        private string _nombre = "Plan Alimentario Test";
        private string _tipo = "Tipo Plan";
        private int _cantidadDias = 2;
        private List<Guid> _recetas = new List<Guid>
        {
            Guid.NewGuid(),
            Guid.NewGuid()
        };
        //Guid idPlanAlimentario, string nombre, string tipo, int cantidadDias, List<Guid> recetas

        [Fact]
        public void CreacionPlanAlimentarioEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new PlanAlimentarioFactory().CreatePlanAlimentario(_idPlanAlimentario, _nombre, _tipo, _cantidadDias, _recetas);

            // Assert
            Assert.Equal(_idPlanAlimentario, ordenTrabajo.Id);
            Assert.Equal(_nombre, ordenTrabajo.Nombre);
            Assert.Equal(_tipo, ordenTrabajo.Tipo);
            Assert.Equal(_cantidadDias, (int)ordenTrabajo.CantidadDias);
            Assert.Equal(_recetas, ordenTrabajo.Recetas.Select(x => x.IdReceta).ToList());
        }

        [Fact]
        public void CreacionPlanAlimentarioEsInvalidoIdPlanAlimentario()
        {
            // Arrange

            // Act
            Action act = () => new PlanAlimentarioFactory().CreatePlanAlimentario(Guid.Empty, _nombre, _tipo, _cantidadDias, _recetas);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CreacionPlanAlimentarioEsInvalidoNombre()
        {
            // Arrange

            // Act
            Action act = () => new PlanAlimentarioFactory().CreatePlanAlimentario(_idPlanAlimentario, string.Empty, _tipo, _cantidadDias, _recetas);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CreacionPlanAlimentarioEsInvalidoTipo()
        {
            // Arrange

            // Act
            Action act = () => new PlanAlimentarioFactory().CreatePlanAlimentario(_idPlanAlimentario, _nombre, string.Empty, _cantidadDias, _recetas);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CreacionPlanAlimentarioEsInvalidoCantidadDias()
        {
            // Arrange

            // Act
            Action act = () => new PlanAlimentarioFactory().CreatePlanAlimentario(_idPlanAlimentario, _nombre, _tipo, 0, _recetas);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void CreacionPlanAlimentarioEsInvalidoRecetas()
        {
            // Arrange

            // Act
            Action act = () => new PlanAlimentarioFactory().CreatePlanAlimentario(_idPlanAlimentario, _nombre, _tipo, _cantidadDias, null);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}