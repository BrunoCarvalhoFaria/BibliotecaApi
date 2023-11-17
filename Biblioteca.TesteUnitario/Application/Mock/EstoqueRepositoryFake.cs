using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.TesteUnitario.Application.Mock
{
    internal class EstoqueRepositoryFake : IEstoqueRepository
    {
        public Task Add(Estoque Objeto)
        {
            return Task.CompletedTask;
        }

        public IEnumerable<Estoque> Buscar(Expression<Func<Estoque, bool>> predicate)
        {
            return new List<Estoque>();
        }

        public Task Delete(Estoque Objeto)
        {
            return Task.CompletedTask;
        }

        public List<Estoque> GetAll()
        {
            return new List<Estoque>();

        }

        public Estoque? GetById(long Id)
        {
            return new Estoque();
                }

        public Task Update(Estoque Objeto)
        {
            return Task.CompletedTask;
        }
    }
}
