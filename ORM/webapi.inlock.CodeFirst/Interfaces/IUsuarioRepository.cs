using webapi.inlock.CodeFirst.Domains;

namespace webapi.inlock.CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
