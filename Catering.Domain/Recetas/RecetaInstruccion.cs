using Catering.Domain.Abstractions;
using Catering.Domain.Ingredientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catering.Domain.Recetas
{
    public class RecetaInstruccion : Entity
    {
        public Guid IdReceta { get; set; }
        public string Instruccion { get; set; }

        public RecetaInstruccion(Guid idReceta, string instruccion) : base(Guid.NewGuid())
        {
            IdReceta = idReceta;
            Instruccion = instruccion;
        }

        public void Update(string instruccion)
        {
            if (string.IsNullOrEmpty(instruccion))
            {
                throw new ArgumentNullException("Instruccion no puede ser nulo");
            }

            Instruccion = instruccion;
        }

        /// <summary>
        /// Needed for EF
        /// </summary>
        private RecetaInstruccion() { }
    }
}
