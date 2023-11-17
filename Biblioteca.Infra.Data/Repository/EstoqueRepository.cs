using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using DrPay.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infra.Data.Repository
{
    public class EstoqueRepository : Repository<Estoque>, IEstoqueRepository
    {
        private readonly DbContextOptions<BibliotecaDbContext> _optionsBuilder;

        public EstoqueRepository(BibliotecaDbContext context) : base(context)
        {
            _optionsBuilder = new DbContextOptions<BibliotecaDbContext>();
        }
    }
}
