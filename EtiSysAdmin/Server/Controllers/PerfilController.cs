using EtiSysAdmin.Server.Servicios;
using EtiSysAdmin.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EtiSysAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilServicio _perfilServicio;
        public PerfilController(IPerfilServicio perfilServicio)
        {
            _perfilServicio = perfilServicio;
        }

        [HttpGet("Lista/{Valor:alpha?}")]
        public async Task<IActionResult> Lista(string Valor = "NA")
        {
            if (Valor == "NA") Valor = "";
            return Ok(await _perfilServicio.Lista(Valor));
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            return Ok(await _perfilServicio.Obtener(Id));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] PerfilDTO modelo)
        {
            return Ok(await _perfilServicio.Crear(modelo));
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] PerfilDTO modelo)
        {
            return Ok(await _perfilServicio.Editar(modelo));
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            return Ok(await _perfilServicio.Eliminar(Id));
        }

    }
}
