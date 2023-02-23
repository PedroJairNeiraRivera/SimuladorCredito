using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServiceArkade.Models.Response;
using WebServiceArkade.Models.ViewModels;
using WebServiceArkade.Servicios;

namespace WebServiceArkade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        
        private ICuentaService _cuentaService;

        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;

        }

    
        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest authRequest)
        {
            Respuesta respuesta = new Respuesta();

            var cuentaResponse = _cuentaService.Auth(authRequest);
            if(cuentaResponse == null)
            {
                respuesta.Mensaje = "Usuario o contraseña Incorrecta";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = cuentaResponse;

            return Ok(respuesta);

        }
        
    }
}
