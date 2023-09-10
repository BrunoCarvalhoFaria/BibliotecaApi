using Drogaria.Domain.Entities.Vendedores;
using Drogaria.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drogaria.Infra.Data.Mapping
{
    public class VendedorMapping : EntityTypeConfiguration<Vendedor>
    {
        public override void Map(EntityTypeBuilder<Vendedor> builder)
        {
            builder.ToTable("Vendedor");
            builder.HasKey(p => p.Id);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(p => p.ClassLevelCascadeMode);
            builder.Ignore(p => p.RuleLevelCascadeMode);
        }
    }
}
