using Catering.Domain.Comidas;
using Catering.Integration.Catering;
using Catering.Integration.EvaluacionNutricional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Tests.Integration.EvaluacionNutricional
{
    public class PlanAlimentarioCreadoTest
    {
        [Fact]
        public void CreacionPlanAlimentarioCreadoEsValido()
        {
            // Arrange            
            Guid idPlanAlimentario = Guid.NewGuid();
            string nombre = "Plan de Alimentación Semanal";
            string tipo = "Plan";
            int cantidadDias = 15;

            // Act
            var orden = new PlanAlimentarioCreado(idPlanAlimentario, nombre, tipo, cantidadDias);

            // Assert
            Assert.Equal(idPlanAlimentario, orden.IdPlanAlimentario);
            Assert.Equal(nombre, orden.Nombre);
            Assert.Equal(tipo, orden.Tipo);
            Assert.Equal(cantidadDias, orden.CantidadDias);
        }
    }
}
