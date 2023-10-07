using Drogaria.Domain.Entities.Caixas;
using Drogaria.Domain.Entities.Faltas;
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
    public class FaltaRepository : Repository<Falta>, IFaltaRepository
    {
        private readonly DbContextOptions<DrogariaDbContext> _optionsBuilder;

        public FaltaRepository(DrogariaDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<DrogariaDbContext>();
        }
    }
}
