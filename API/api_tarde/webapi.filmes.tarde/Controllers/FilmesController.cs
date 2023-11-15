using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{

    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de API
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API é JSON
    /// </summary>


    [Produces("application/json")]

    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

    public FilmesController()
    {
        _filmeRepository = new FilmeRepository();
    }

        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                //Faz a chamada para o método cadastrar
                _filmeRepository.Cadastrar(novoFilme);

                //retorna um status code
                return Created("objeto criado", novoFilme);
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
                
            List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();
                return Ok(listaFilmes);
            }
            catch (Exception erro)
            {

                BadRequest(erro.Message);
                throw;
            }
            
        }
        
        
        [HttpGet("{id}")]
         public IActionResult GetById(int id)
         {

            try
            {
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);
                if (filmeBuscado == null)
                {
                    return NotFound();
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
              return BadRequest(erro.Message);
                
            }
            
          }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
                throw;
            }
                
            

        }

        [HttpPut]
         public IActionResult PutIdUrl(int id)
        {

            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para apresentar que houve erro
                if (filmeBuscado == null)
                {
                    return NotFound
                        (new
                        {
                            mensagem = "Filme não encontrado!",
                            erro = true
                        }
                        );
                }

                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdUrl()
                    _filmeRepository.AtualizarIdUrl(id, filmeBuscado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um status 400 - BadRequest e o código do erro
                    return BadRequest(erro);
                }
            }
            catch (Exception erro)
            {

                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }




        }





        



    }
}
