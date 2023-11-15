using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario);
    }
}
