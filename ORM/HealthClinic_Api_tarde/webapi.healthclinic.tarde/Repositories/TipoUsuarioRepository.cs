using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthClinicContext ctx;
        public TipoUsuarioRepository()
        {

            ctx = new HealthClinicContext();


        }
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public void Deletar(Guid id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id)!;
            if (tipoUsuarioBuscado !=null)
            {
                ctx.TipoUsuario.Remove(tipoUsuarioBuscado);
                ctx.SaveChanges();
            }


        }
    }
}
