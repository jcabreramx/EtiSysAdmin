using EtiSysAdmin.Server.Servicios;
using EtiSysAdmin.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EtiSysAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestoController : ControllerBase
    {
        private readonly IPuestoServicio _puestoServicio;
        public PuestoController(IPuestoServicio puestoServicio)
        {
            _puestoServicio = puestoServicio;
        }

        [HttpGet("Lista/{Valor:alpha?}")]
        public async Task<IActionResult> Lista(string Valor = "NA")
        {
            if (Valor == "NA") Valor = "";
            return Ok(await _puestoServicio.Lista(Valor));
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            return Ok(await _puestoServicio.Obtener(Id));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PuestoDTO modelo)
        {
            return Ok(await _puestoServicio.Crear(modelo));
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] PuestoDTO modelo)
        {
            return Ok(await _puestoServicio.Editar(modelo));
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            return Ok(await _puestoServicio.Eliminar(Id));
        }

    }
}
