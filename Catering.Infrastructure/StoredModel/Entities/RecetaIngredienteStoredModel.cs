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
    [Table("RecetaIngrediente")]
    public class RecetaIngredienteStoredModel
    {
        [Key]
        [Column("IdRecetaIngrediente")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Receta")]
        public Guid IdReceta { get; set; }
        public virtual RecetaStoredModel Receta { get; set; }

        [Required]
        [ForeignKey("Ingrediente")]
        public Guid IdIngrediente { get; set; }
        public virtual IngredienteStoredModel Ingrediente { get; set; }

        [Column("Detalle")]
        [StringLength(250)]
        public string Detalle { get; private set; }

        [Required]
        [Column("Cantidad", TypeName = "decimal(18,2)")]
        public float Cantidad { get; private set; }
    }
}
