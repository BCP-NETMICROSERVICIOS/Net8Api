using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Venta.Application.CasosUso.AdministrarProductos.ActualizarProducto;
using Venta.Application.CasosUso.AdministrarProductos.ConsultarProductos;
using Venta.Application.CasosUso.AdministrarProductos.RegistrarProducto;

namespace Venta.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configInfo;

        public ProductosController(IMediator mediator, IConfiguration configInfo)
        {
            _mediator = mediator;
            _configInfo = configInfo;
        }

        [HttpGet("consultar")]
        public async Task<IActionResult> Consultar([FromQuery] ConsultarProductosRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] RegistrarProductoRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarProductoRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
