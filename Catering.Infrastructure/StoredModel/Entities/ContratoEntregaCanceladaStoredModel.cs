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
    [Table("ContratoEntregaCancelada")]
    public class ContratoEntregaCanceladaStoredModel
    {
        [Key]
        [Column("IdContratoEntregaCancelada")]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("Contrato")]
        public Guid IdContrato { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual ContratoStoredModel Contrato { get; set; }

        [Required]
        [Column("FechaCancelada")]
        public DateTime FechaCancelada { get; set; }
    }
}
