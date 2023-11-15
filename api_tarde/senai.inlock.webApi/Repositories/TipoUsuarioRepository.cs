using senai.inlock.webApi.Domains;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class TipoUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE21-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";
        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "Insert into TipoUsuario(Titulo) Values ('" + novoTipoUsuario.Titulo + "')";
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.ExecuteNonQuery();



                }


            }

        }
    }
 }