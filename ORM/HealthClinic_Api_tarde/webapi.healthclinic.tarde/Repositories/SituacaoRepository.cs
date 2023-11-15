using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        private readonly HealthClinicContext ctx;
        public SituacaoRepository()
        {

            ctx = new HealthClinicContext();


        }


        public void Atualizar(Situacao tipoUsuario, Guid id)
        {
            Situacao situacaoBuscada = ctx.Situacao.Find(id)!;
            if (situacaoBuscada != null)
            {
                situacaoBuscada.Titulo = tipoUsuario.Titulo;
            }

        }

        public void Cadastrar(Situacao tipoUsuario)
        {
            try
            {
                ctx.Situacao.Add(tipoUsuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Situacao situacaoBuscada = ctx.Situacao.Find(id)!;
            if (situacaoBuscada != null)
            {
                ctx.Situacao.Remove(situacaoBuscada);
                ctx.SaveChanges();
            }
        }
    }
}
