using System.Linq.Expressions;

namespace Drogaria.Domain.Interfaces
{
    public interface IRepository { }

    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity Objeto);
        Task Delete(TEntity Objeto);
        Task<TEntity> GetById(long Id);
        Task<List<TEntity>> GetAll();
        Task Update(TEntity Objeto);

    }
}
