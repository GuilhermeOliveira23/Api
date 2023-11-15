using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {

        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public TipoUsuarioDomain?  TipoUsuario { get; set;}

        [Required(ErrorMessage = "O campo Email é obrigatório!!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório!!")]
        public string Senha { get; set; }

        
    }
}
