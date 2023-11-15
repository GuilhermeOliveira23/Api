using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{

    public interface IFilmeRepository
    {


        void Cadastrar(FilmeDomain novoFilme);

        List<FilmeDomain> ListarTodos();

        FilmeDomain BuscarPorId(int id);

        

        void AtualizarIdPor(FilmeDomain Filme);


        /// <summary>
        /// Atualizar um Gênero existente passando o id pelo o url da requisição
        /// </summary>
        /// <param name="Id">Id do objeto a ser atualizado</param>
        /// <param name="Filme">Objeto com as novas informações</param>
        void AtualizarIdUrl(int Id, FilmeDomain Filme);

        /// <summary>
        /// Deletar um gênero existente
        /// </summary>
        /// <param name="Id">Id do objeto a ser deletado</param>

        void Deletar(int Id);

    }
}