using Catering.Domain.Abstractions;
using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;

namespace Catering.Domain.Recetas
{
    public class Receta : AggregateRoot
    {
        private List<RecetaInstruccion> _instruccionesList;
        private List<RecetaIngrediente> _ingredientesList;

        public string Nombre { get; private set; }
        public ICollection<RecetaIngrediente> Ingredientes { get => _ingredientesList; }
        public ICollection<RecetaInstruccion> Instrucciones { get => _instruccionesList; }

        public Receta(Guid id, string nombre) : base(id)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentNullException("Nombre de la receta no puede ser vacío o nulo", nameof(nombre));
            }

            Nombre = nombre;
            _ingredientesList = new List<RecetaIngrediente>();
            _instruccionesList = new List<RecetaInstruccion>();
        }

        public void UpdateNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentNullException("Nombre de la receta no puede ser vacío o nulo", nameof(nombre));
            }
            Nombre = nombre.Trim();
        }

        #region Ingredientes
        public void AddIngrediente(Guid idIngrediente, string detalle, float cantidad)
        {
            if (idIngrediente == Guid.Empty)
            {
                throw new ArgumentException("Ingrediente no puede ser vacío", nameof(idIngrediente));
            }
            if (cantidad <= 0)
            {
                throw new ArgumentNullException("Cantidad no puede ser menor o igual a 0");
            }

            RecetaIngrediente IngredienteReceta = new RecetaIngrediente(Id, idIngrediente, detalle, cantidad);
            _ingredientesList.Add(IngredienteReceta);
        }

        public void UpdateIngrediente(Guid idRecetaIngrediente, Guid idIngrediente, string detalle, float cantidad)
        {
            if (idIngrediente == Guid.Empty)
            {
                throw new ArgumentException("Ingrediente no puede ser vacío", nameof(idIngrediente));
            }
            if (cantidad <= 0)
            {
                throw new ArgumentNullException("Cantidad no puede ser menor o igual a 0", nameof(cantidad));
            }

            RecetaIngrediente IngredienteReceta = _ingredientesList.FirstOrDefault(x => x.Id == idRecetaIngrediente);
            if (IngredienteReceta == null)
            {
                throw new InvalidOperationException("Ingrediente no encontrado en la receta");
            }

            IngredienteReceta.Update(idIngrediente, detalle, cantidad);
        }

        public void RemoveIngrediente(Guid idRecetaIngrediente)
        {
            if (idRecetaIngrediente == Guid.Empty)
            {
                throw new ArgumentException("Ingrediente no puede ser vacío", nameof(idRecetaIngrediente));
            }

            RecetaIngrediente IngredienteReceta = _ingredientesList.FirstOrDefault(x => x.Id == idRecetaIngrediente);
            if (IngredienteReceta == null)
            {
                throw new InvalidOperationException("Ingrediente no encontrado en la receta");
            }
            _ingredientesList.Remove(IngredienteReceta);
        }
        #endregion Ingredientes

        #region Instruciones
        public void AddInstrucciones(string instruccion)
        {
            if (string.IsNullOrEmpty(instruccion))
            {
                throw new ArgumentNullException("Instrucción no puede ser vacío", nameof(instruccion));
            }
            var recetaInstruccion = new RecetaInstruccion(Id, instruccion);
            _instruccionesList.Add(recetaInstruccion);
        }

        public void UpdateInstruccion(Guid idInstruccion, string instruccion)
        {
            if (idInstruccion == Guid.Empty)
            {
                throw new ArgumentNullException("Instrucción no puede ser vacío", nameof(idInstruccion));
            }
            if (string.IsNullOrEmpty(instruccion))
            {
                throw new ArgumentNullException("Instrucción no puede ser vacío", nameof(instruccion));
            }

            RecetaInstruccion recetaInstruccion = _instruccionesList.FirstOrDefault(x => x.Id == idInstruccion);
            if (recetaInstruccion == null)
            {
                throw new InvalidOperationException("Ingrediente no encontrado en la receta");
            }
            recetaInstruccion.Update(instruccion);
        }

        public void RemoveInstruccion(Guid idInstruccion)
        {
            if (idInstruccion == Guid.Empty)
            {
                throw new ArgumentException("Instrucción no puede ser vacío", nameof(idInstruccion));
            }

            RecetaInstruccion recetaInstruccion = _instruccionesList.FirstOrDefault(x => x.Id == idInstruccion);
            if (recetaInstruccion == null)
            {
                throw new InvalidOperationException("Instrucción no encontrado en la receta");
            }
            _instruccionesList.Remove(recetaInstruccion);
        }
        #endregion Instruciones

        /// <summary>
        /// Prepara la comida de la receta.
        /// </summary>
        /// <returns>Comida en estado Preparado.</returns>
        public Comida PrepararReceta(Guid idOrdenTrabajo)
        {
            var comida = new Comida(Nombre, idOrdenTrabajo);
            comida.Preparar(_ingredientesList);
            return comida;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private Receta() { }

    }
}
