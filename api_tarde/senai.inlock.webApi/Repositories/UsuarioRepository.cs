using System.Data.SqlClient;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;

namespace senai.inlock.webApi.Repositories
{



    public class UsuarioRepository : IUsuarioRepository
    {

        private string StringConexao = "Data Source = NOTE21-S15; Initial Catalog = inlock_games; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection  con =  new SqlConnection(StringConexao))
            {
                string queryLogin = "Select IdUsuario,Email from Usuario Where Email = @Email and Senha = @Senha";

                con.Open();


                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();


                    if (rdr.Read())
                    {

                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),

                            Email = rdr["Email"].ToString(),

                            Senha = rdr["Senha"].ToString()



                            //Falta add o IdTipoUsuario
                        };
                        return usuario;
                    }
                    return null;
                }

            }


        }
    }
}
