using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.Persistence
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext(DbContextOptions<GenericDbContext> options)
          : base(options)
        {

        }

        protected GenericDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
