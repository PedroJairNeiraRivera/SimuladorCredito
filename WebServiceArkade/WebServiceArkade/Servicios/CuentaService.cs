/*using WebServiceArkade.Models.Response;
using WebServiceArkade.Models.ViewModels;
using WebServiceArkade.Models;
using WebServiceArkade.Tools;
using WebServiceArkade.Models.Common;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace WebServiceArkade.Servicios
{
    public class CuentaService : ICuentaService
    {
        
        private AppSettings _appSettings;
        public CuentaService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

        }
        public CuentaResponse Auth(AuthRequest model) {

            CuentaResponse cuentaResponse = new CuentaResponse();
            using (var db = new ArkadeArquitectContext())
            {
                string spassword = Encriptador.GetSHA256(model.password);

                var cuenta = db.Cuenta.Where(d => d.Email == model.email &&
                d.Contraseña == spassword).FirstOrDefault();
                if (cuenta == null) return null;
                
                cuentaResponse.email = cuenta.Email;
                cuentaResponse.Token = GetToken(cuenta);
            }
            return cuentaResponse;
        }
        
        private string GetToken(Cuentum cuenta)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(

                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,cuenta.IdCuenta.ToString()),
                        new Claim(ClaimTypes.Email,cuenta.Email)

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
*/