using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.OrdenesTrabajo.Exceptions
{
    public class OrdenTrabajoCreationException : Exception
    {
        public OrdenTrabajoCreationException(string reason)
            : base("La orden de trabajo no pudo crearse: " + reason)
        {
        }
    }
}
