using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthClinicContext ctx;
        public EspecialidadeRepository()
        {

            ctx = new HealthClinicContext();


        }
        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                ctx.Especialidade.Add(especialidade);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public void Deletar(Guid id)
        {
            Especialidade especialidadeBuscada = ctx.Especialidade.Find(id)!;
            if (especialidadeBuscada != null)
            {
                ctx.Especialidade.Remove(especialidadeBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
