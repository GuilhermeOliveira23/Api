using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Contexts
{
    public class HealthClinicContext :DbContext
    {

        //Todas as tabelas com que for trabalhar  no projeto tem que estar aqui
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<FeedBack> FeedBack { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Situacao> Situacao { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE21-S15; Database=HealthClinic_API_tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
