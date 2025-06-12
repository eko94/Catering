using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.OrdenesTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.PlanAlimentario
{
    public class PlanAlimentario : AggregateRoot
    {
        public string Nombre { get; private set; }
        public string Tipo { get; private set; }
        public PlanAlimentarioCantidadDias CantidadDias { get; private set; }
        private List<PlanAlimentarioReceta>? _recetasList { get; set; }
        public ICollection<PlanAlimentarioReceta> Recetas { get { return _recetasList; } }
        public PlanAlimentario(Guid id, string nombre, string tipo, int cantidadDias, List<PlanAlimentarioReceta> recetas) : base(id)
        {
            Nombre = nombre;
            Tipo = tipo;
            CantidadDias = cantidadDias;
            _recetasList = recetas;
        }

        #region Recetas
        public void AddReceta(Guid idReceta, int dia)
        {
            if (_recetasList.Any(x => x.Dia == dia))
            {
                throw new InvalidOperationException("Ya está asignado una receta en el día seleccionado.");
            }
            if (_recetasList.Any(x => x.IdReceta == idReceta))
            {
                throw new InvalidOperationException("La receta ya está en el plan alimentario.");
            }

            PlanAlimentarioReceta planReceta = new(Id, idReceta, dia);
            _recetasList.Add(planReceta);
        }
        public void UpdateReceta(Guid idReceta, int dia)
        {
            if (!_recetasList.Any(x => x.IdReceta == idReceta))
            {
                throw new InvalidOperationException("La receta no se encuentra en el plan alimentario.");
            }
            if (_recetasList.Any(x => x.Dia == dia))
            {
                throw new InvalidOperationException("Ya está asignado una receta en el día seleccionado.");
            }
            var receta = _recetasList.First(x => x.IdReceta == idReceta);
            receta.Update(idReceta, dia);
        }
        public void RemoveReceta(Guid idReceta)
        {
            if (!_recetasList.Any(x => x.IdReceta == idReceta))
            {
                throw new InvalidOperationException("La receta no se encuentra en el plan alimentario.");
            }

            var receta = _recetasList.First(x => x.IdReceta == idReceta);
            _recetasList.Remove(receta);
        }
        #endregion

        /// <summary>
        /// Needed for EF
        /// </summary>
        private PlanAlimentario() { }
    }
}
