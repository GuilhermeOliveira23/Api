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
    public class PacienteController : ControllerBase
    {

        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {

            _pacienteRepository = new PacienteRepository();
        }


        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Paciente paciente)
        {

            try
            {
                _pacienteRepository.Cadastrar(paciente);
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

                _pacienteRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }




        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]

        public IActionResult Put(Paciente paciente, Guid id)
        {
            try
            {
                _pacienteRepository.Atualizar(paciente, id);
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
