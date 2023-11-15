using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Id do usuário é obrigatório!")]
        public Guid IdUsuario { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Id da clínica é obrigatório!")]
        public Guid IdClinica { get; set; }
        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
        [Required(ErrorMessage = "Id da especialidade é obrigatório!")]
        public Guid IdEspecialidade { get; set; }
        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        //depois alterar para Char(n) e criar outra migration
        [Column(TypeName = "CHAR(12)")]
        [Required(ErrorMessage = "CRM do médico é obrigatório")]
        [StringLength(12, ErrorMessage = "CRM deve conter menos de 12 caracteres!")]
        public string? CRM { get; set; }
    }
}
