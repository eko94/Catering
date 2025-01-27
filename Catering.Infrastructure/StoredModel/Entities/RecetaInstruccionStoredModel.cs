using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel.Entities
{
    [Table("RecetaInstruccion")]
    public class RecetaInstruccionStoredModel
    {
        [Key]
        [Column("IdRecetaInstruccion")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Receta")]
        public Guid IdReceta { get; set; }
        public virtual RecetaStoredModel Receta { get; set; }

        [Column("Instruccion")]
        [StringLength(250)]
        [Required]
        public string Instruccion { get; set; }
    }
}
