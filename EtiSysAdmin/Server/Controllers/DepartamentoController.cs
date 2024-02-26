using EtiSysAdmin.Server.Servicios;
using EtiSysAdmin.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EtiSysAdmin.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoServicio _departamentoServicio;
        public DepartamentoController(IDepartamentoServicio departamentoServicio)
        {
            _departamentoServicio = departamentoServicio;
        }

        [HttpGet("Lista/{Valor:alpha?}")]
        public async Task<IActionResult> Lista(string Valor = "NA")
        {
            if (Valor == "NA") Valor = "";
            return Ok(await _departamentoServicio.Lista(Valor));
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            return Ok(await _departamentoServicio.Obtener(Id));
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] DepartamentoDTO modelo)
        {
            return Ok(await _departamentoServicio.Crear(modelo));
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] DepartamentoDTO modelo)
        {
            return Ok(await _departamentoServicio.Editar(modelo));
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            return Ok(await _departamentoServicio.Eliminar(Id));
        }

    }
}
