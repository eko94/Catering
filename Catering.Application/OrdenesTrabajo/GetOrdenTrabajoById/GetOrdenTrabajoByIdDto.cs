using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.OrdenesTrabajo.GetOrdenTrabajoById
{
    public class GetOrdenTrabajoByIdDto
    {
        public Guid Id { get; set; }
        public string UsuarioCocineroNombre { get; set; }
        public string RecetaNombre { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
    }
}
