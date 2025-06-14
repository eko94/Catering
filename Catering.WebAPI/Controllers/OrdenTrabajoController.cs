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
    public class OrdenTrabajoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdenTrabajoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] CrearOrdenCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return Ok(id);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("preparar-receta")]
        public async Task<IActionResult> PrepararReceta([FromBody] PrepararRecetaCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("empaquetar-comidas")]
        public async Task<IActionResult> EmpaquetarComidasCommand([FromBody] EmpaquetarComidasCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("etiquetar-comidas")]
        public async Task<IActionResult> EtiquetarComidas([FromBody] EtiquetarComidasCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("cancelar-orden")]
        public async Task<IActionResult> CancelarOrden([FromBody] CancelarOrdenCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTransaction([FromRoute] Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetOrdenTrabajoByIdQuery(id));
                return Ok(result);
            }
            catch (Exception ex)
            {
                SentrySdk.CaptureException(ex);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("obtener-por-usuario-estado")]
        public async Task<IActionResult> GetTransactionByUserState([FromRoute] Guid idUsuario, string estado)
        {
            try
            {
                var result = await _mediator.Send(new GetOrdenesTrabajoByUserStateQuery(idUsuario, estado));
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
