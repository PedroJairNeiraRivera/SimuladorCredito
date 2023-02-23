using System;
using System.Collections.Generic;

namespace WebServiceArkade.Models;

public partial class Usuario
{
    public long IdUsuario { get; set; }

    public string Nombres { get; set; } = null!;

    public int Celular { get; set; }

    public string Direccion { get; set; } = null!;

    public string? Sexo { get; set; }

    public string? Email { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Contraseña { get; set; }

    public string TipoAsociacion { get; set; } = null!;
}
