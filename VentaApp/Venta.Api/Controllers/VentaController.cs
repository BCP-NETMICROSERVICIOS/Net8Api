using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 

using Venta.Application.CasosUso.AdministrarVentas.RegistrarVenta;

namespace Venta.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarVentaRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
 


    }
}