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
    public class PlanAlimentarioTests
    {
        private Guid _idPlanAlimentario = Guid.NewGuid();
        private string _nombre = "Plan Alimentario Test";
        private string _tipo = "Tipo Plan";
        private int _cantidadDias = 2;
        private List<PlanAlimentarioReceta> _recetas = new List<PlanAlimentarioReceta>();

        [Fact]
        public void CreacionPlanAlimentarioEsValido()
        {
            // Arrange

            // Act
            var ordenTrabajo = new PlanAlimentario(_idPlanAlimentario, _nombre, _tipo, _cantidadDias, _recetas);

            // Assert
            Assert.Equal(_idPlanAlimentario, ordenTrabajo.Id);
            Assert.Equal(_nombre, ordenTrabajo.Nombre);
            Assert.Equal(_tipo, ordenTrabajo.Tipo);
            Assert.Equal(_cantidadDias, (int)ordenTrabajo.CantidadDias);
            Assert.Equal(_recetas, ordenTrabajo.Recetas.ToList());
        }

        [Fact]
        public void PlanAlimentarioAddReceta()
        {
            // Arrange
            var recetaId = Guid.NewGuid();
            var dia = 1;

            // Act
            var ordenTrabajo = new PlanAlimentario(_idPlanAlimentario, _nombre, _tipo, _cantidadDias, _recetas);
            ordenTrabajo.AddReceta(recetaId, dia);

            // Assert
            Assert.Equal(recetaId, ordenTrabajo.Recetas.First().IdReceta);
            Assert.Equal(dia, (int)ordenTrabajo.Recetas.First().Dia);
        }

        [Fact]
        public void PlanAlimentarioUpdateReceta()
        {
            // Arrange
            var recetaId = Guid.NewGuid();
            var dia = 1;
            var diaUpdate = 2;

            // Act
            var ordenTrabajo = new PlanAlimentario(_idPlanAlimentario, _nombre, _tipo, _cantidadDias, _recetas);
            ordenTrabajo.AddReceta(recetaId, dia);
            ordenTrabajo.UpdateReceta(recetaId, diaUpdate);

            // Assert
            Assert.Equal(recetaId, ordenTrabajo.Recetas.First().IdReceta);
            Assert.Equal(diaUpdate, (int)ordenTrabajo.Recetas.First().Dia);
        }

        [Fact]
        public void PlanAlimentarioRemoveReceta()
        {
            // Arrange
            var recetaId = Guid.NewGuid();
            var dia = 1;
            var diaUpdate = 2;

            // Act
            var ordenTrabajo = new PlanAlimentario(_idPlanAlimentario, _nombre, _tipo, _cantidadDias, _recetas);
            ordenTrabajo.AddReceta(recetaId, dia);
            ordenTrabajo.RemoveReceta(recetaId);

            // Assert
            Assert.Null(ordenTrabajo.Recetas.FirstOrDefault(x => x.IdReceta == recetaId));
        }
    }
}