using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Contexts
{
    public class EventContext : DbContext
    {
        //Todas as tabelas com que for trabalhar  no projeto tem que estar aqui
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE21-S15; Database=event+_tarde; User Id=sa; Pwd=Senai@134; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
