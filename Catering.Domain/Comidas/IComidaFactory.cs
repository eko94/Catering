using Catering.Domain.OrdenesTrabajo;
using Catering.Domain.Recetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Comidas
{
    public interface IComidaFactory
    {
        Comida CreateComida(Guid id, string nombre);
    }
}
