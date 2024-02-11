using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.CasosUso.AdministrarPagos.RegistrarPago;

 

namespace Venta.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PagoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PagoController(IMediator mediator)
        {
            _mediator = mediator;
        }

         
        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] RegistrarPagoRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }


    }
}