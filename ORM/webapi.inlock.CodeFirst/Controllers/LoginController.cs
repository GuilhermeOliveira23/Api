using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.CodeFirst.Domains;
using webapi.inlock.CodeFirst.Interfaces;
using webapi.inlock.CodeFirst.Repositories;
using webapi.inlock.CodeFirst.ViewModels;

namespace webapi.inlock.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private  IUsuarioRepository _usuarioRepository;

        public LoginController()
        {

            _usuarioRepository = new UsuarioRepository();
        }



        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {

            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email!, usuario.Senha!);
                return StatusCode(401, "Email ou senha inválidos!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }


        }



    }
}
