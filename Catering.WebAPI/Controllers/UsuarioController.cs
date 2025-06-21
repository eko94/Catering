using Catering.Application.OrdenesTrabajo.CancelarOrden;
using Catering.Application.OrdenesTrabajo.CrearOrden;
using Catering.Application.OrdenesTrabajo.EmpaquetarComidas;
using Catering.Application.OrdenesTrabajo.EtiquetarComidas;
using Catering.Application.OrdenesTrabajo.GetOrdenesTrabajo;
using Catering.Application.OrdenesTrabajo.GetOrdenTrabajoById;
using Catering.Application.OrdenesTrabajo.PrepararReceta;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catering.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("obtener-usuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var result = await _mediator.Send(new GetUsuariosQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(500);
            }
        }
    }
}
