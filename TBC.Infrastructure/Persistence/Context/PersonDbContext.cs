using Common.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using TBC.Domain.Entities.CityAggregate;
using TBC.Domain.Entities.PersonAggregate;

namespace TBC.Infrastructure.Persistence.Context
{
    public class PersonDbContext : GenericDbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<RelatedPerson> RelatedPeople { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public PersonDbContext(DbContextOptions<PersonDbContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonDbContext).Assembly);
        }
    }
}
