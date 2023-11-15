using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthClinicContext ctx;
        public ClinicaRepository()
        {

            ctx = new HealthClinicContext();


        }
        public void Cadastrar(Clinica clinica)
        {
            try
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void Deletar(Guid id)
        {
            Clinica clinica = ctx.Clinica.Find(id)!;
            if (clinica != null)
            {
                ctx.Clinica.Remove(clinica);
                ctx.SaveChanges();
            }

        }
    }
}
