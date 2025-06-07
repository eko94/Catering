using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel.Entities
{
    [Table("PlanAlimentario")]
    public class PlanAlimentarioStoredModel
    {
        [Key]
        [Column("IdPlanAlimentario")]
        public Guid Id { get; set; }

        [Required]
        [Column("Nombre")]
        [MaxLength(250)]
        public string Nombre { get; set; }

        [Required]
        [Column("Tipo")]
        [MaxLength(100)]
        public string Tipo { get; set; }

        [Required]
        [Column("CantidadDias")]
        public int CantidadDias { get; set; }

        public ICollection<PlanAlimentarioRecetaStoredModel>? Recetas { get; set; } = new List<PlanAlimentarioRecetaStoredModel>();
    }
}
