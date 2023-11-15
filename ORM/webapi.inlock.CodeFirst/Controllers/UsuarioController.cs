using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.CodeFirst.Domains;
using webapi.inlock.CodeFirst.Interfaces;
using webapi.inlock.CodeFirst.Repositories;

namespace webapi.inlock.CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Login(Usuario usuario)
        {

            Usuario  usuarioBuscado = 

        }

        //falta implementar o endpoint




    }



}

