using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(FeedBack))]
    public class FeedBack
    {
        [Key]
        public Guid IdFeedBack { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Id da consulta é obrigatório")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Comentário do paciente é obrigatório!")]
        [StringLength(100, ErrorMessage = "Comentario não deve ultrapassar 100 caracteres!")]
        public string? Comentario { get; set; }
    }
}
