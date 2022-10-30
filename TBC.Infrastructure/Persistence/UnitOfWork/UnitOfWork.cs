using System.Threading;
using System.Threading.Tasks;
using TBC.Domain.Entities.CityAggregate;
using TBC.Domain.Entities.PersonAggregate;
using TBC.Domain.SeedWork;
using TBC.Infrastructure.Persistence.Context;

namespace TBC.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonDbContext _context;

        public ICityRepository CityRepository { get; }
        public IPersonRepository PersonRepository { get; }

        public UnitOfWork(
            PersonDbContext context, 
            ICityRepository cityRepository, 
            IPersonRepository personRepository
            )
        {
            _context = context;
            CityRepository = cityRepository;
            PersonRepository = personRepository;
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
