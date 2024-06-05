using Microsoft.EntityFrameworkCore;
using SeaMI.Models;


namespace SeaMI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<AmostraAgua> AmostrasAgua { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<RelatorioAmostra> RelatoriosAmostra { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("TB_GS_USUARIO");
            modelBuilder.Entity<Login>().ToTable("TB_GS_LOGIN");
            modelBuilder.Entity<AmostraAgua>().ToTable("TB_GS_AMOSTRA_AGUA");
            modelBuilder.Entity<Relatorio>().ToTable("TB_GS_RELATORIO");
            modelBuilder.Entity<RelatorioAmostra>().ToTable("TB_GS_RELATORIO_AMOSTRA");

            modelBuilder.Entity<Login>()
                .HasOne(l => l.Usuario)
                .WithMany(u => u.Logins)
                .HasForeignKey(l => l.cdUsuario);

            modelBuilder.Entity<AmostraAgua>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.AmostrasAgua)
                .HasForeignKey(a => a.cdUsuario);

            modelBuilder.Entity<Relatorio>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Relatorios)
                .HasForeignKey(r => r.cdUsuario);

            modelBuilder.Entity<RelatorioAmostra>()
                .HasOne(ra => ra.AmostraAgua)
                .WithMany(a => a.RelatoriosAmostra)
                .HasForeignKey(ra => ra.cdAmostra);

            modelBuilder.Entity<RelatorioAmostra>()
                .HasOne(ra => ra.Relatorio)
                .WithMany(r => r.RelatoriosAmostra)
                .HasForeignKey(ra => ra.cdRelatorio);

            base.OnModelCreating(modelBuilder);
        }
    }
}
