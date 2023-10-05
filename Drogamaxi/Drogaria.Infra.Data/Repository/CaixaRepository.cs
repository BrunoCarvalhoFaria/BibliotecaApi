
using DrPay.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Drogaria.Domain.Entities.Caixas;
using Drogaria.Domain.Interfaces;

namespace Drogaria.Infra.Data.Repository
{
    public class CaixaRepository : Repository<Caixa>, ICaixaRepository
    {
        private readonly DbContextOptions<DrogariaDbContext> _optionsBuilder;

        public CaixaRepository(DrogariaDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<DrogariaDbContext>();
        }
    }
}
