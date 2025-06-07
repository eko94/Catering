using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel.Entities
{
    [Table("PlanAlimentarioReceta")]
    public class PlanAlimentarioRecetaStoredModel
    {
        [Key]
        [Column("IdPlanAlimentarioReceta")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("PlanAlimentario")]
        public Guid IdPlanAlimentario { get; set; }
        public virtual PlanAlimentarioStoredModel PlanAlimentario { get; set; }

        [Required]
        [ForeignKey("Receta")]
        public Guid IdReceta { get; set; }
        public virtual RecetaStoredModel Receta { get; set; }

        [Required]
        [Column("Dia")]
        public int Dia { get; set; }
    }
}
