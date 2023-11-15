using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface ISituacaoRepository
    {
        void Cadastrar(Situacao situacao);
        void Deletar(Guid id);
        void Atualizar(Situacao situacao, Guid id);
    }
}
