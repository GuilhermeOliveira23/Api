using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Id do paciente é obrigatório")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        [Required(ErrorMessage = "Id da situação é obrigatório")]
        public Guid IdSituacao { get; set; }

        [ForeignKey(nameof(IdSituacao))]
        public Situacao? Situacao { get; set; }


        [Required(ErrorMessage = "Id do médico é obrigatório")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        [Column(TypeName ="VARCHAR(100)")]
        [Required(ErrorMessage = "Id do médico é obrigatório")]
        public string? Descricao { get; set; }
        
        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "Data do agendamento é obrigatória")]
        public DateTime? DataAgendamento { get; set; }
        

    }
}
