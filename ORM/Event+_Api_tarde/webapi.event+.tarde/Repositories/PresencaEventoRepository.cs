using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEvento
    {
        private readonly EventContext ctx;

        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento presencaEventoBuscada = ctx.PresencaEvento.Find(id);
            if (presencaEventoBuscada != null)
            {
                presencaEventoBuscada.Situacao = presencaEvento.Situacao;
                presencaEventoBuscada.IdUsuario = presencaEvento.IdUsuario;
                presencaEventoBuscada.IdEvento = presencaEvento.IdEvento;
                ctx.SaveChanges();
            }
            
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
           return  ctx.PresencaEvento.Find(id)!;
        }

        public void Cadastrar(PresencaEvento presencaEvento)
        {
            ctx.PresencaEvento.Add(presencaEvento);
            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            PresencaEvento presencaEventoBuscada = ctx.PresencaEvento.Find(id)!;
            if (presencaEventoBuscada != null)
            {
                ctx.PresencaEvento.Remove(presencaEventoBuscada);
                ctx.SaveChanges();
            }
        }

        public List<PresencaEvento> Listar()
        {
           return ctx.PresencaEvento.ToList();
        }

        
    }
}
