using Drogaria.Domain.Entities.Caixas;
using Drogaria.Domain.Entities.Fornecedores;
using Drogaria.Domain.Interfaces;
using DrPay.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drogaria.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        private readonly DbContextOptions<DrogariaDbContext> _optionsBuilder;

        public FornecedorRepository(DrogariaDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<DrogariaDbContext>();
        }
    }
}
