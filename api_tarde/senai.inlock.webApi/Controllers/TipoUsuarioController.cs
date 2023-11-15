using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{

    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _tipoUsuarioRepository;

        


        [HttpPost]
        public IActionResult Post(TipoUsuarioDomain novoUsuario)
        {
            try
            {
                //Faz a chamada para o método cadastrar
                _tipoUsuarioRepository.Cadastrar(novoUsuario);

                //retorna um status code
                return Created("objeto criado", novoUsuario);
                //return StatusCode(201)
            }
            catch (Exception erro)
            {

                //Retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
                throw;
            }


        }


    }
}


