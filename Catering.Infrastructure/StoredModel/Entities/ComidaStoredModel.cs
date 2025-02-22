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
    [Table("Comida")]
    public class ComidaStoredModel
    {
        [Key]
        [Column("IdComida")]
        public Guid Id { get; set; }

        [Required]
        [Column("Nombre")]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [Column("Estado")]
        [StringLength(25)]
        public string Estado { get; private set; }

        [ForeignKey("Cliente")]
        public Guid? IdCliente { get; set; }
        public virtual ClienteStoredModel Cliente { get; set; }

        [Required]
        [ForeignKey("OrdenTrabajo")]
        public Guid IdOrdenTrabajo { get; set; }
        public virtual OrdenTrabajoStoredModel OrdenTrabajo { get; set; }

    }
}
