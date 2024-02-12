using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll(); // Veritabanında select işlemi yapmadan önce sorguyu ekler.
        IQueryable<T> Where(Expression<Func<T, bool>> expression); // Veritabanında select işlemi yapmadan önce sorguyu ekler.
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T Entity);
        void Remove(T Entity);
        void RemoveRange(IEnumerable<T> Entities);
    }
}
