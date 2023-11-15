using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.Data;

namespace senai.inlock.webApi.Controllers
{

    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]



    public class JogosController : ControllerBase
    {
        private JogosRepository _jogosRepository { get; set; }


        public JogosController() 
        {
            _jogosRepository = new JogosRepository();
        }


        [HttpPost]
        
        public IActionResult Post(JogosDomain novoJogo)
        {
            try
            {
                //Faz a chamada para o método cadastrar
                _jogosRepository.Cadastrar(novoJogo);

                //retorna um status code
                return Created("objeto criado", novoJogo);
                //return StatusCode(201)
            }
            catch (Exception erro)
            {

                //Retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
                throw;
            }


        }

        [HttpGet]

        public IActionResult Get()
        {


            try
            {
                //Cria uma lista para receber os generos
                List<JogosDomain> listaJogos = _jogosRepository.ListarTodos();
                // retorna a lista no formato de JSON e o status code(Ok = 200)
                return Ok(listaJogos);
            }

            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
                throw;
            }

        }
    }
}