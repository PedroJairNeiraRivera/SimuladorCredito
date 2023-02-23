namespace WebServiceArkade.Models.ViewModels
{
    public class UsuarioRequest
    {
        public long IdUsuario { get; set; }

        public string Nombres { get; set; }

        public int Celular { get; set; }

        public string Direccion { get; set; } 

        public string? Sexo { get; set; }

        public string? Email { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string TipoAsociacion { get; set; } 

        public string Password{ get; set; }
    }
}
