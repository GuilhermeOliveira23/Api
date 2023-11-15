using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;

namespace webapi.healthclinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SituacaoController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository;

        public SituacaoController()
        {

            _situacaoRepository = new SituacaoRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Médico")]
        public IActionResult Post(Situacao situacao)
        {

            try
            {
                _situacaoRepository.Cadastrar(situacao);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }



        }

        [HttpDelete]
        [Authorize(Roles = "Médico")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                _situacaoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }




        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Médico")]

        public IActionResult Put(Situacao situacao, Guid id)
        {
            try
            {
                _situacaoRepository.Atualizar(situacao, id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }



        }
    }
}
