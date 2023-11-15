using Microsoft.AspNetCore.Http.HttpResults;
using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {

        private readonly HealthClinicContext ctx;
        public PacienteRepository()
        {

            ctx = new HealthClinicContext();


        }
        public void Atualizar(Paciente paciente, Guid id)
        {
            Paciente pacienteBuscado = ctx.Paciente.Find(id)!;
            if (pacienteBuscado != null)
            {
                pacienteBuscado.CPF = paciente.CPF;
                pacienteBuscado.Telefone = paciente.Telefone;
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
             ctx.Paciente.Add(paciente);
                ctx.SaveChanges();
            }
            catch (Exception)
            {
               
                throw;
            }
           
        }

        public void Deletar(Guid id)
        {
            Paciente pacienteBuscado = ctx.Paciente.Find(id)!;
            if (pacienteBuscado !=null)
            {
                ctx.Paciente.Remove(pacienteBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Paciente> ListarComConsulta()
        {
            throw new NotImplementedException();
        }
    }
}
