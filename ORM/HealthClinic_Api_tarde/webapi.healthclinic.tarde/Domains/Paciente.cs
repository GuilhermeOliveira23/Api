using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(11)")]
        [Required(ErrorMessage = "CPF do paciente é obrigatório!")]
        [StringLength(11, ErrorMessage = "CPF não pode ter mais de 11 caracteres!")]
        public string? CPF { get; set; }
        [Column(TypeName = "INT")]
        [Required(ErrorMessage = "Telefone do paciente é obrigatório!")]
        public int? Telefone { get; set; }
    }
}
