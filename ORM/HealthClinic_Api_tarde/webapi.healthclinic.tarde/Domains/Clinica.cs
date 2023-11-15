using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "CNPJ da Clínica é obrigatório!")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "NomeFantasia da Clínica é obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "RazaoSocial da Clínica é obrigatório!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Endereco da Clínica é obrigatório!")]
        public string? Endereco { get; set; }

        
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Hora de abertura da clínica é obrigatória!")]
        public TimeSpan? HoraAbertura { get; set; }

        
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Hora de fechamento da clínica é obrigatório!")]
        public TimeSpan? HoraFechamento { get; set; }






    }
}
