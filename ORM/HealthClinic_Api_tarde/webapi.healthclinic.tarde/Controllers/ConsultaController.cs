using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;
using webapi.healthclinic.tarde.Repositories;

namespace webapi.healthclinic.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {

            _consultaRepository = new ConsultaRepository();
        }



        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Consulta consulta)
        {


            try
            {
                _consultaRepository.Cadastrar(consulta);
                return StatusCode(201);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }


        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                _consultaRepository.Deletar(id);
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


        public IActionResult Put(Consulta consulta, Guid id)
        {
            try
            {
                _consultaRepository.Atualizar(consulta, id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }



        }

        [HttpGet("BuscarPorIdMedico")]
        [Authorize(Roles = "Médico")]
        public IActionResult GetByIdMedico(Guid id) 
       
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorIdMedico(id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        
        }


        [HttpGet("BuscarPorIdPaciente")]
        [Authorize(Roles = "Paciente")]

        public IActionResult GetByIdPaciente(Guid id)

        {
            try
            {
                return Ok(_consultaRepository.BuscarPorIdPaciente(id));

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }


        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_consultaRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }



        }


    }
}
