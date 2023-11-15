using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {


        private string StringConexao = "Data Source = NOTE21-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        public void AtualizarIdPor(FilmeDomain filme)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query a ser executada
                string queryUpdateBody = "UPDATE Filme SET Filme.IdGenero = @IdGenero, Filme.Titulo = @Titulo WHERE IdFilme = @IFilme";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@IFilme", filme.IdFilme);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "Update Filme Set Titulo = @Titulo Where IdFilme = @IdFilme";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                String? querySelectById = "Select * From Filme Where IdFilme = @IdFilme";


                SqlDataReader rdr;


                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr["IdFilme"]),

                            Titulo = rdr["Titulo"].ToString()

                        };


                        return filmeBuscado;

                    }
                    return null;


                }

            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme(IdGenero,Titulo) Values ('" + novoFilme.IdGenero + "', '" + novoFilme.Titulo + "')";



                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    con.Open();

                    cmd.ExecuteNonQuery();
                }


            }

        }
        

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme Where IdFilme = @IdFilme";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {

            //Cria uma lista de generos onde será armazenados os generos
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara  a instrução a ser executada
                string? querySelectAll = "Select IdFilme, Filme.IdGenero,Titulo, Nome From Filme left join Genero on Filme.IdGenero  = Genero.IdGenero";


                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader rdr;


                //Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr
                    //o laço se repetirá
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            //Atribui a propriedade IdGenero o valor da primeira coluna da tabela
                            IdFilme = Convert.ToInt32(rdr[0]),

                            IdGenero = Convert.ToInt32(rdr[1]),

                            //Atribui a propriedade Nome o valor da coluna Nome
                            Titulo = rdr["Titulo"].ToString(),

                           Genero = new GeneroDomain()
                           {
                             

                             Nome = rdr["Nome"].ToString()
                             
                           }



                        };
                            
                        listaFilmes.Add(filme);
                       
                    }
                    

                };


                return listaFilmes;
            }

        }
    }
}