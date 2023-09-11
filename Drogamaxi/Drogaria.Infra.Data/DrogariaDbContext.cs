using Microsoft.EntityFrameworkCore;
using Drogaria.Domain.Entities.Vendedores;
using Drogaria.Infra.Data.Extensions;
using Drogaria.Infra.Data.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Drogaria.Domain.Entities.ApplicationUsers;
using Drogaria.Domain.DTO;
using Microsoft.Extensions.Configuration;

namespace Drogaria.Infra.Data
{
    public class DrogariaDbContext : IdentityDbContext<ApplicationUser>
    {
        public DrogariaDbContext(DbContextOptions<DrogariaDbContext> options) : base(options) 
        { 

        }

        //public DbSet<Message> Message { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

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


            modelBuilder.AddConfiguration(new VendedorMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
