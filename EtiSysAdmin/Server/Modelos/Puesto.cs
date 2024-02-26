namespace EtiSysAdmin.Server.Modelos;

public partial class Puesto
{
    public int IdPuesto { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }
    public bool? Estatus { get; set; }


}
