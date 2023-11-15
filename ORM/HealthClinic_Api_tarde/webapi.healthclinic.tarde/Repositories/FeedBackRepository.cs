using webapi.healthclinic.tarde.Contexts;
using webapi.healthclinic.tarde.Domains;
using webapi.healthclinic.tarde.Interfaces;

namespace webapi.healthclinic.tarde.Repositories
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly HealthClinicContext ctx;
        public FeedBackRepository()
        {

            ctx = new HealthClinicContext();


        }


        public void Atualizar(FeedBack feedBack, Guid id)
        {
            FeedBack feedBackBuscado = ctx.FeedBack.Find(id)!;
            if (feedBackBuscado != null)
            {
                feedBackBuscado.IdConsulta = feedBack.IdConsulta;
                feedBackBuscado.Comentario = feedBack.Comentario;
            }

        }

        public void Cadastrar(FeedBack feedBack)
        {
            try
            {
                ctx.FeedBack.Add(feedBack);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            };
        }

        public void Deletar(Guid id)
        {
            FeedBack feedBackBuscado = ctx.FeedBack.Find(id)!;
            if (feedBackBuscado != null)
            {
                ctx.FeedBack.Remove(feedBackBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
