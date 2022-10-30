using Common.Infrastructure.Persistence;
using TBC.Domain.Entities.CityAggregate;
using TBC.Infrastructure.Persistence.Context;

namespace TBC.Infrastructure.Persistence.Repositories
{
    public class CityRepository : GenericRepository<City,PersonDbContext>, ICityRepository
    {
        public CityRepository(PersonDbContext context)
            : base(context)
        {

        }
    }
}
