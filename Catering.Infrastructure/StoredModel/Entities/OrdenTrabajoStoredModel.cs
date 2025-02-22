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
    [Table("OrdenTrabajo")]
    public class OrdenTrabajoStoredModel
    {
        [Key]
        [Column("IdOrdenTrabajo")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("UsuarioCocinero")]
        public Guid IdUsuarioCocinero { get; set; }
        public UsuarioStoredModel UsuarioCocinero { get; set; }

        [Required]
        [ForeignKey("Receta")]
        public Guid IdReceta { get; set; }
        public virtual RecetaStoredModel Receta { get; set; }

        [Required]
        [Column("Cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [Column("Estado")]
        [MaxLength(25)]
        public string Estado { get; set; }

        [Required]
        [Column("Tipo")]
        [MaxLength(25)]
        public string Tipo { get; set; }

        [Required]
        [Column("FechaCreado")]
        public DateTime FechaCreado { get; set; }

        public ICollection<ComidaStoredModel>? Comidas { get; set; } = new List<ComidaStoredModel>();

        public ICollection<OrdenTrabajoClienteStoredModel>? Clientes { get; set; } = new List<OrdenTrabajoClienteStoredModel>();
    }
}
