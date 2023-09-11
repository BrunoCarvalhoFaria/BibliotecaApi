using Drogaria.Domain.Entities.Vendedores;
using Drogaria.Domain.Entities.Vendedores.Repository;
using DrPay.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drogaria.Infra.Data.Repository
{
    public class VendedorRepository : Repository<Vendedor>, IVendedorRepository
    {
        private readonly DbContextOptions<DrogariaDbContext> _optionsBuilder;

        public VendedorRepository(DrogariaDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<DrogariaDbContext>();
        }
    }
}
