namespace EtiSysAdmin.Server.Modelos;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }
    public bool? Estatus { get; set; }


}
