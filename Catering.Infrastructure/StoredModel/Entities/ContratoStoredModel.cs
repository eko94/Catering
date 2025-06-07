using Catering.Domain.Clientes;
using Catering.Domain.Comidas;
using Catering.Domain.Contratos;
using Catering.Domain.OrdenesTrabajo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel.Entities
{
    [Table("Contrato")]
    public class ContratoStoredModel
    {
        [Key]
        [Column("IdContrato")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public Guid IdCliente { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual ClienteStoredModel Cliente { get; set; }

        [Required]
        [ForeignKey("PlanAlimentario")]
        public Guid IdPlanAlimentario { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual PlanAlimentarioStoredModel PlanAlimentario { get; set; }

        [Required]
        [Column("DiasContratados")]
        public int DiasContratados { get; set; }

        [Column("DiasRealizados")]
        public int DiasRealizados { get; set; }

        [Required]
        [Column("Estado")]
        [MaxLength(25)]
        public string Estado { get; set; }

        [Required]
        [Column("FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [Column("FechaUltimoRealizado")]
        public DateTime? FechaUltimoRealizado { get; set; }

        public ICollection<ContratoEntregaCanceladaStoredModel>? EntregasCanceladas { get; set; } = new List<ContratoEntregaCanceladaStoredModel>();
    }
}
