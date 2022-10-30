using Common.Infrastructure.Persistence;
using TBC.Domain.Entities.PersonAggregate;
using TBC.Infrastructure.Persistence.Context;

namespace TBC.Infrastructure.Persistence.Repositories
{
    public class PersonRepository : GenericRepository<Person,PersonDbContext>,IPersonRepository
    {
        public PersonRepository(PersonDbContext context)
            : base(context)
        {

        }

    }
}
