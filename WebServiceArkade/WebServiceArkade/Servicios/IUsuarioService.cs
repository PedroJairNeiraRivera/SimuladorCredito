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
    public interface IUsuarioService
    {
        UsuarioResponse Auth(AuthRequest model);
    }
}
