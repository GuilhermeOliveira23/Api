using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthClinicContext ctx;
        public MedicoRepository()
        {

            ctx = new HealthClinicContext();


        }

        public void Atualizar(Medico medico, Guid id)
        {
            Medico medicoBuscado =  ctx.Medico.Find(id)!;
            if (medicoBuscado !=null)
            {
                medicoBuscado.IdUsuario = medico.IdUsuario;
                medicoBuscado.IdClinica= medico.IdClinica;
                medicoBuscado.IdEspecialidade = medico.IdClinica;
                medicoBuscado.CRM = medico.CRM;

                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                ctx.Medico.Add(medico);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Medico medicoBuscado = ctx.Medico.Find(id)!;
            if (medicoBuscado != null)
            {
                ctx.Medico.Remove(medicoBuscado);
                ctx.SaveChanges();
            }
        }

    }
}
