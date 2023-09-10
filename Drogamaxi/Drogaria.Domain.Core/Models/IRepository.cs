using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Drogaria.Domain.Core.Models
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        void Adicionar(TEntity Objeto);
        void Atualizar(TEntity Objeto);
        void Remover(long id);
        TEntity ObterPorId(long id);
        IEnumerable<TEntity> ObterTodos();
    }
}
