using System.ComponentModel.DataAnnotations;

namespace EtiSysAdmin.Shared
{
    public class PuestoDTO
    {
        public int IdPuesto { get; set; }
        [Required(ErrorMessage = "Ingrese nombre")]
        public string? Nombre { get; set; }
        public bool? Estatus { get; set; }
    }
}
