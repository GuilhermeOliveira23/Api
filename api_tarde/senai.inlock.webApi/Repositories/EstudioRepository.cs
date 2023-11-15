using senai.inlock.webApi.Domains;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository
    {

        private string StringConexao = "Data Source = NOTE21-S15; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "Insert into Estudio(Nome) Values ('" + novoEstudio.Nome + "')";

                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.ExecuteNonQuery();



                }


            }


        }
    }
}
