using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{

    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {

        //CRUD
        //tipo de retorno NomeMetodo(TipoParametro NomeParametro)
        /// <summary>
        /// Cadastrar um novo Gênero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retornar todos os gêneros cadastrados
        /// </summary>
        /// <returns>Uma lista e gêneros</returns>
        

        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Atualizar um gênero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="Genero"> Objeto com as novas informações</param>

        
       ///
       ///Buscar um objeto através de seu id
       ///


        GeneroDomain BuscarPorId(int id);


        void AtualizarIdPor(GeneroDomain Genero);


        /// <summary>
        /// Atualizar um Gênero existente passando o id pelo o url da requisição
        /// </summary>
        /// <param name="Id">Id do objeto a ser atualizado</param>
        /// <param name="Genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int Id, GeneroDomain Genero);

        /// <summary>
        /// Deletar um gênero existente
        /// </summary>
        /// <param name="Id">Id do objeto a ser deletado</param>

        void Deletar(int Id);


    }
}
