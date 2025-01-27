using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Infrastructure.StoredModel.Entities
{
    [Table("Usuario")]
    public class UsuarioStoredModel
    {
        [Key]
        [Column("IdUsuario")]
        public Guid Id { get; set; }

        [Column("Nombre")]
        [StringLength(250)]
        [Required]
        public string Nombre { get; set; }
    }
}
