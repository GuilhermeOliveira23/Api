using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class FilmeDomain
    {

        public int IdFilme { get; set; }
        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        public string? Titulo  { get; set; }

        public int IdGenero { get; set; }
        /// <summary>
        /// Referência para a classe Genero
        /// </summary>
        public GeneroDomain? Genero { get; set; }
    }
}
