using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Biblioteca.Domain.Entities.ApplicationUsers;
using Biblioteca.Domain.DTO;
using Microsoft.Extensions.Configuration;

namespace Biblioteca.Infra.Data
{
    public class BibliotecaDbContext : IdentityDbContext<ApplicationUser>
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) 
        { 

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);

            }
        }
        public string ObterStringConexao()
        {
            return Configuracoes.Configuration.GetConnectionString("ConnectionMysql");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
