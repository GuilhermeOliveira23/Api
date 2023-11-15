using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogosRepository
    {

        void Cadastrar(JogosDomain novoJogo);
        List<JogosDomain> ListarTodos();
    }
}
