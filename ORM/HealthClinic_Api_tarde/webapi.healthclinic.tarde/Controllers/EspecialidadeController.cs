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
    public class EspecialidadeController : ControllerBase
    {

        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {

            _especialidadeRepository = new EspecialidadeRepository();
        }




        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Especialidade especialidade)
        {

            try
            {
                _especialidadeRepository.Cadastrar(especialidade);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }



        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                _especialidadeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }


        }
    }
}
