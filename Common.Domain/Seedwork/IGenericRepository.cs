using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Domain.Seedwork
{
    public interface IGenericRepository<T> where T : class
    { 
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default); 
        Task<int> CountAsync(IQueryable<T> data, CancellationToken cancellationToken = default); 
        IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default); 
        Task<List<T>> ToListAsync(IQueryable<T> data, CancellationToken cancellationToken = default); 
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);
        void Update(T entity);
    }
}
