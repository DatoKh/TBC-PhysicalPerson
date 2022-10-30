using Common.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Infrastructure.Persistence
{
    public class GenericRepository<T, DC> : IGenericRepository<T> where T : class
            where DC : DbContext
    {
        public readonly DC Context;

        public GenericRepository(DC context)
        {
            Context = context;
        } 

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Context.AddAsync(entity, cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().AsNoTracking().AnyAsync(where, cancellationToken);
        } 

        public async Task<int> CountAsync(IQueryable<T> data, CancellationToken cancellationToken = default)
        {
            return await data.AsNoTracking().CountAsync(cancellationToken);
        } 

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> @where)
        {
            return Context.Set<T>().Where(where);
        }

        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        } 

        public virtual async Task<List<T>> ToListAsync(IQueryable<T> data, CancellationToken cancellationToken = default)
        {
            return await data.AsNoTracking().ToListAsync(cancellationToken);
        }
         

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> @where, CancellationToken cancellationToken = default)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(where, cancellationToken);
        }

        public virtual void Update(T entity)
        {
            Context.Update(entity);
        }
    }
}
