using Microsoft.EntityFrameworkCore;
using SeaMI.Models;

namespace SeaMI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Login> Login { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
