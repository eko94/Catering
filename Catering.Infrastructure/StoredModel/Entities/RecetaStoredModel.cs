using Catering.Domain.Comidas;
using Catering.Domain.Ingredientes;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel.Entities
{
    [Table("Receta")]
    public class RecetaStoredModel
    {
        [Key]
        [Column("IdReceta")]
        public Guid Id { get; set; }

        [Column("Nombre")]
        [StringLength(250)]
        [Required]
        public string Nombre { get; set; }

        public ICollection<RecetaIngredienteStoredModel>? Ingredientes { get; set; } = new List<RecetaIngredienteStoredModel>();

        public ICollection<RecetaInstruccionStoredModel>? Instrucciones { get; set; } = new List<RecetaInstruccionStoredModel>();
    }
}
