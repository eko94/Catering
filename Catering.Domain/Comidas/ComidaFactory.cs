using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Comidas
{
    public class ComidaFactory : IComidaFactory
    {
        public Comida CreateComida(Guid id, string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentNullException("Nombre no puede ser vacío o nulo", nameof(nombre));
            }

            return new Comida(nombre, id);
        }
    }
}
