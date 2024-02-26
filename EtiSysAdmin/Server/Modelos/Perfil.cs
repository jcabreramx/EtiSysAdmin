namespace EtiSysAdmin.Server.Modelos;

public partial class Perfil
{
    public int IdPerfil { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }
    public bool? Estatus { get; set; }


}
