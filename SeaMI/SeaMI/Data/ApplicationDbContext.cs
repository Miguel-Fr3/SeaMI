using Microsoft.EntityFrameworkCore;
using SeaMI.Models;

namespace SeaMI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        public DbSet<AmostraAgua> AmostraAguas { get; set; }

        public DbSet<AmostraUsuario> AmostraUsuarios { get; set; }

        public DbSet<AprovacaoRelatorio> AprovacaoRelatorios { get; set; }

        public DbSet<Login> Logins { get; set; }

        public DbSet<MonitoramentoAgua> MonitoramentoAguas { get; set; }

        public DbSet<RelatorioAgua> RelatorioAguas { get; set; }

        public DbSet<Sensores> Sensores { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
