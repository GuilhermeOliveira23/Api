using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Deletar(Guid id);
        void Atualizar(Guid id , Usuario usuario);
        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEmailSenha(string email, string senha);
        List<Usuario> Listar();
    }
}
