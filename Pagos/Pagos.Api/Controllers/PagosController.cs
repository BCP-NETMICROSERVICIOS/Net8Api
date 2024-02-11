using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pagos.Application.CasosUso.RegistraPagos;


namespace Pagos.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PagosController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarPagoRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
