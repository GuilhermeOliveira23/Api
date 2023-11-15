using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
{

    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato
    /// dominio/api/nomeController
    /// exemplo: http://localhost:7288/api/Genero
    /// </summary>
    /// 
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de API
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API é JSON
    /// </summary>



    [Produces("application/json")]
    public class GenerosController : ControllerBase
    {

        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// Instância o objeto _generoRepository para que haja referência 
        /// aos métodos no repositório
        /// </summary>
        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }
        /// <summary>
        /// Endpoint que acessa o método de listar gêneros
        /// </summary>
        /// <returns>Lista de gêneros e um status code</returns>

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {


            try
            {
                //Cria uma lista para receber os generos
                List<GeneroDomain> listaGenero = _generoRepository.ListarTodos();
                // retorna a lista no formato de JSON e o status code(Ok = 200)
                return Ok(listaGenero);
            }

            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
                throw;
            }


        }

        [HttpPost]
        public IActionResult Post(GeneroDomain  novoGenero)
        {
            try
            {
                //Faz a chamada para o método cadastrar
                _generoRepository.Cadastrar(novoGenero);

                //retorna um status code
                return Created("objeto criado", novoGenero);
                //return StatusCode(201)
            }
            catch (Exception erro)
            {

                //Retorna um status code BadRequest (400) e a mensagem de erro
                return BadRequest(erro.Message);
                throw;
            }


        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);
                return StatusCode(204);
            }

            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            try
            {   

                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);
                if (generoBuscado == null)
                {
                    return NotFound();
                }
                
                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult PutIdBody(GeneroDomain genero)
        {
            try
            {
              GeneroDomain generoBuscado  = _generoRepository.BuscarPorId(genero.IdGenero);
                if (generoBuscado != null)
                {
                    try
                    {
                    _generoRepository.AtualizarIdPor(genero);
                    return NoContent();
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);

                    }
                    
                }
                return NotFound("Gênero não encontrado !");
            }
            
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
                
            }
        }

        [HttpPut]
        public IActionResult PutIdUrl(int id, GeneroDomain genero)
        {

            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);
                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdUrl(id, genero);
                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Genero não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
                
            }

        }
    }
}
