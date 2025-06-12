using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Application.Contratos.GetContratosRealizarDelDia
{
    public class GetContratosRealizarDelDiaDto
    {
        public Guid IdContrato { get; set; }
        public Guid IdCliente { get; set; }
        public Guid IdReceta { get; set; }
    }
}