using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IFeedBackRepository
    {
        void Cadastrar(FeedBack feedBack);
        void Deletar(Guid id);
        void Atualizar(FeedBack feedBack, Guid id);
        
    }
}
