using System;
using System.Collections.Generic;

namespace WebServiceArkade.Models;

public partial class Cuentum
{
    public int IdCuenta { get; set; }

    public string Cuenta { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Email { get; set; } = null!;
}
