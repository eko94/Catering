namespace Catering.Application.OrdenesTrabajo.GetOrdenesTrabajo
{
    public class GetOrdenesTrabajoByUserStateDto
    {
        public Guid Id { get; set; }
        public string UsuarioCocineroNombre { get; set; }
        public string RecetaNombre { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public string Tipo { get; set; }
    }
}
