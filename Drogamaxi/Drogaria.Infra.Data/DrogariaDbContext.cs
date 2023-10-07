using Microsoft.EntityFrameworkCore;
using Drogaria.Domain.Entities.Vendedores;
using Drogaria.Infra.Data.Extensions;
using Drogaria.Infra.Data.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Drogaria.Domain.Entities.ApplicationUsers;
using Drogaria.Domain.DTO;
using Microsoft.Extensions.Configuration;
using Drogaria.Domain.Entities.Caixas;
using Drogaria.Domain.Entities.Fornecedores;
using Drogaria.Domain.Entities.Faltas;

namespace Drogaria.Infra.Data
{
    public class DrogariaDbContext : IdentityDbContext<ApplicationUser>
    {
        public DrogariaDbContext(DbContextOptions<DrogariaDbContext> options) : base(options) 
        { 

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Falta> Falta { get; set; }

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
            modelBuilder.AddConfiguration(new CaixaMapping());
            modelBuilder.AddConfiguration(new FornecedorMapping());
            modelBuilder.AddConfiguration(new FaltaMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
