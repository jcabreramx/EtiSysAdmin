using EtiSysAdmin.Server.Servicios;
using EtiSysAdmin.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EtiSysAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaServicio _ventaServicio;
        public VentaController(IVentaServicio ventaServicio)
        {
            _ventaServicio = ventaServicio;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO modelo)
        {
            return Ok(await _ventaServicio.Registrar(modelo));
        }
    }
}
