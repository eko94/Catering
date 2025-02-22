using Catering.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel.Entities
{
    [Table("Ingrediente")]
    public class IngredienteStoredModel
    {
        [Key]
        [Column("IdIngrediente")]
        public Guid Id { get; set; }

        [Required]
        [Column("Nombre")]
        [StringLength(250)]
        public string Nombre { get; set; }

        [Required]
        [Column("Medicion")]
        [StringLength(250)]
        public string Medicion { get; set; }

        [Required]
        [Column("Tipo")]
        [StringLength(250)]
        public string Tipo { get; set; }

        [Required]
        [Column("CostoCompra", TypeName = "decimal(18,2)")]
        public decimal CostoCompra { get; set; }

        [Required]
        [Column("CostoVenta", TypeName = "decimal(18,2)")]
        public decimal CostoVenta { get; set; }
    }
}
