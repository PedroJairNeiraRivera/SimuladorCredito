using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebServiceArkade.Models.Common;
using WebServiceArkade.Models.Response;
using WebServiceArkade.Models.ViewModels;
using WebServiceArkade.Models;
using WebServiceArkade.Tools;

namespace WebServiceArkade.Servicios
{
    public class UsuarioService: IUsuarioService
    {
        private AppSettings _appSettings;
        public UsuarioService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

        }
        public UsuarioResponse Auth(AuthRequest model)
        {

            UsuarioResponse usuarioResponse = new UsuarioResponse();
            using (var db = new ArkadeArquitectContext())
            {
                string spassword = Encriptador.GetSHA256(model.password);

                var usuario = db.Usuarios.Where(d => d.Email == model.email &&
                d.Contraseña == spassword).FirstOrDefault();
                if (usuario == null) return null;

                usuarioResponse.email = usuario.Email;
                usuarioResponse.Token = GetToken(usuario);
                usuarioResponse.tipo = usuario.TipoAsociacion;
                usuarioResponse.password = usuario.Contraseña;
            }
            return usuarioResponse;
        }

       

        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(

                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,usuario.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Email,usuario.Email)

                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
