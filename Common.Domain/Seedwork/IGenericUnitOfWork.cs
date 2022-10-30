using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Domain.Seedwork
{
    public interface IGenericUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
