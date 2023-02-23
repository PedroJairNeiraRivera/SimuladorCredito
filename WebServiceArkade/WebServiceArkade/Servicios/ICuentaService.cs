using System.Security.Cryptography.Xml;
using WebServiceArkade.Models;
using WebServiceArkade.Models.ViewModels;
using WebServiceArkade.Models.Response;
using WebServiceArkade.Tools;

namespace WebServiceArkade.Servicios
{
    public interface ICuentaService
    {
        CuentaResponse Auth(AuthRequest model);

    }
}
