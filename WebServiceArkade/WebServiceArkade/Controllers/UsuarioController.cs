using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebServiceArkade.Models;
using WebServiceArkade.Models.Response;
using WebServiceArkade.Models.ViewModels;
using WebServiceArkade.Servicios;

namespace WebServiceArkade.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]


    public class UsuarioController : ControllerBase
    {

        private IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;

        }


        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest authRequest)
        {
            Respuesta respuesta = new Respuesta();

            var cuentaResponse = _usuarioService.Auth(authRequest);
            if (cuentaResponse == null)
            {
                respuesta.Mensaje = "Usuario o contraseña Incorrecta";
                return BadRequest(respuesta);
            }
            respuesta.Exito = 1;
            respuesta.Data = cuentaResponse;

            return Ok(respuesta);

        }

        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {

                using (ArkadeArquitectContext db = new ArkadeArquitectContext())
                {
                    var list = db.Usuarios.OrderByDescending(d=>d.IdUsuario).ToList();
                    respuesta.Exito = 1;
                    respuesta.Data = list;

                }
            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);

        }
        [HttpPost]
        public IActionResult Add(UsuarioRequest usuarioRequest)
        {

            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using (ArkadeArquitectContext db = new ArkadeArquitectContext())
                {
                    Usuario usuario = new Usuario();

                    usuario.Nombres = usuarioRequest.Nombres;
                    usuario.Celular = usuarioRequest.Celular;
                    usuario.Direccion = usuarioRequest.Direccion;
                    usuario.Sexo = usuarioRequest.Sexo;
                    usuario.Email = usuarioRequest.Email;
                    usuario.Direccion = usuarioRequest.Direccion;
                    usuario.FechaNacimiento = usuarioRequest.FechaNacimiento;
                    usuario.TipoAsociacion = usuarioRequest.TipoAsociacion;
                    usuario.Contraseña = usuarioRequest.Password;

                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    respuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;

            }
            return Ok(respuesta);
        }

        [HttpPut]
        public IActionResult Update(UsuarioRequest usuarioRequest)
        {
            Respuesta respuesta = new Respuesta();
          
            try
            {
                using (ArkadeArquitectContext db = new ArkadeArquitectContext())
                {
                    Usuario usuario = db.Usuarios.Find(usuarioRequest.IdUsuario);

                    usuario.Nombres = usuarioRequest.Nombres;
                    usuario.Celular = usuarioRequest.Celular;
                    usuario.Direccion = usuarioRequest.Direccion;
                    usuario.Sexo = usuarioRequest.Sexo;
                    usuario.Email = usuarioRequest.Email;
                    usuario.Direccion = usuarioRequest.Direccion;
                    usuario.FechaNacimiento = usuarioRequest.FechaNacimiento;
                    usuario.TipoAsociacion = usuarioRequest.TipoAsociacion;
                    usuario.Contraseña = usuarioRequest.Password;

                    db.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    respuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;

            }
            return Ok(respuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Exito = 0;
            try
            {
                using (ArkadeArquitectContext db = new ArkadeArquitectContext())
                {
                    
                    Usuario usuario = db.Usuarios.Find(Id);
                    db.Remove(usuario);
                    db.SaveChanges();
                    respuesta.Exito = 1;

                }
            }
            catch (Exception ex)
            {

                respuesta.Mensaje = ex.Message;

            }
            return Ok(respuesta);
        } 
        
    }
    
}
