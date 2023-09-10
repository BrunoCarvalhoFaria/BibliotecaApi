using Microsoft.EntityFrameworkCore;
using Drogaria.Domain.Entities.Vendedores;
using Drogaria.Infra.Data.Extensions;
using Drogaria.Infra.Data.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Drogaria.Domain.Entities.ApplicationUsers;

namespace Drogaria.Infra.Data
{
    public class DrogariaDbContext : IdentityDbContext<ApplicationUser>
    {
        public DrogariaDbContext(DbContextOptions<DrogariaDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);


            modelBuilder.AddConfiguration(new VendedorMapping());

            //base.OnModelCreating(modelBuilder);
        }
    }
}
