using System.ComponentModel.DataAnnotations;

namespace EtiSysAdmin.Shared
{
    public class PerfilDTO
    {
        public int IdPerfil { get; set; }
        [Required(ErrorMessage = "Ingrese nombre")]
        public string? Nombre { get; set; }
        public bool? Estatus { get; set; }
    }
}
