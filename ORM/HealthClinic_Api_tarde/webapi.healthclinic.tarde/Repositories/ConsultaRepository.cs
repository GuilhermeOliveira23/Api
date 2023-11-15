using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {

        private readonly HealthClinicContext ctx;
        public ConsultaRepository()
        {

            ctx = new HealthClinicContext();


        }
        public void Atualizar(Consulta consulta, Guid id)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id)!;
            if (consultaBuscada != null)
            {
                consultaBuscada.IdSituacao = consulta.IdSituacao;
                consultaBuscada.IdMedico = consulta.IdMedico;
                consultaBuscada.IdPaciente = consulta.IdPaciente;
                consultaBuscada.Descricao = consulta.Descricao;
                consultaBuscada.DataAgendamento = consulta.DataAgendamento;

                ctx.SaveChanges();
            }
        }

        public Consulta BuscarPorIdMedico(Guid id)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdMedico == id)!;
        }

        public Consulta BuscarPorIdPaciente(Guid id)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdPaciente == id)!;
        }

        public void Cadastrar(Consulta consulta)
        {
            try
            {
                ctx.Consulta.Add(consulta);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id)!;
            if (consultaBuscada != null)
            {
                ctx.Consulta.Remove(consultaBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta.ToList();
        }

    }
}
