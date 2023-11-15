using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros:
        /// Data Source : Nome do servidor do banco
        /// Initial Catalog: Nome do banco de dados
        /// Autenticação
        /// -windows : Integrated Security = True
        /// -SqlServer : User Id = sa; Pwd = Senha
        /// </summary>
        /// 

        private string StringConexao = "Data Source = NOTE21-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Atualizar um gênero passando seu id pelo corpo da requisição
        /// </summary>
        /// <param name="Genero">Objeto com as novas informações</param>
        public void AtualizarIdPor(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String queryUpdateIdBody = "Update Genero Set Nome = @Nome Where IdGenero = @IdGenero";


                con.Open();


                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {


                    cmd.Parameters.AddWithValue("@Nome",genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "Update Genero Set Nome = @Nome Where IdGenero = @IdGenero";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    cmd.ExecuteNonQuery();
                }
            }
           
        }
        /// <summary>
        /// Buscar um gênero através do seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String? querySelectById = "Select * From Genero Where IdGenero = @IdGenero";
                

                SqlDataReader rdr;

               
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();
                    
                    
                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Nome = rdr["Nome"].ToString()

                        };


                        return generoBuscado;

                    }
                    return null;
                    
                    
                }

            }

            
        }

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero"></param>
        /// <exception cref="NotImplementedException"> objeto com as informações que serão cada</exception>

        //Declara a sqlConnection passando a string de conexão como parâmetro


        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Genero(Nome) Values ('" + novoGenero.Nome + "')";



            using (SqlCommand cmd = new SqlCommand(queryInsert,con))
            {

                con.Open();

                cmd.ExecuteNonQuery();
            }
                
        

            }
            
        }

        


        /// <summary>
        /// Listar todos os objetos do tipo gênero
        /// </summary>
        /// <returns>Lista de objetos do tipo gênero</returns>
        
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de generos onde será armazenados os generos
           List<GeneroDomain> listaGeneros =  new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara  a instrução a ser executada
                string? querySelectAll = "Select IdGenero, Nome From Genero";


                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader rdr;


                //Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    //Executa a query e armazena os dados no rdr
                   rdr =  cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr
                    //o laço se repetirá
                    while (rdr.Read()) {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor da primeira coluna da tabela
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade Nome o valor da coluna Nome
                            Nome = rdr["Nome"].ToString()

                        };

                        //Adiciona o objeto criado dentro da lista
                        listaGeneros.Add(genero);
                    
                    }
                }

                

            }

            //retorna a lista de gêneros
            return listaGeneros;
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Genero  Where IdGenero = @IdGenero";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}



