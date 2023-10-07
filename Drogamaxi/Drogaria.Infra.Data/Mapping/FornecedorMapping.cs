using Drogaria.Domain.Entities.Caixas;
using Drogaria.Domain.Entities.Fornecedores;
using Drogaria.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drogaria.Infra.Data.Mapping
{
    public class FornecedorMapping : EntityTypeConfiguration<Fornecedor>
    {
        public override void Map(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");
            builder.HasKey(p => p.Id);

            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(p => p.ClassLevelCascadeMode);
            builder.Ignore(p => p.RuleLevelCascadeMode);
        }
    }
}
