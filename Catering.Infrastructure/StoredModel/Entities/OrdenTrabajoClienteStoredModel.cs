using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel.Entities
{
    [Table("OrdenTrabajoCliente")]
    public class OrdenTrabajoClienteStoredModel
    {
        [Key]
        [Column("IdOrdenTrabajoCliente")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("OrdenTrabajo")]
        public Guid IdOrdenTrabajo { get; set; }
        public virtual OrdenTrabajoStoredModel OrdenTrabajo { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public Guid IdCliente { get; set; }
        public virtual ClienteStoredModel Cliente { get; set; }

        [Required]
        [ForeignKey("Contrato")]
        public Guid IdContrato { get; set; }
        public virtual ContratoStoredModel Contrato { get; set; }
    }
}
