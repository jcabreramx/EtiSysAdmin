﻿using System;
using System.Collections.Generic;

namespace EtiSysAdmin.Server.Modelos;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public string? Rol { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? IdPuesto { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdRol { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
