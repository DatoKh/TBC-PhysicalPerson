using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.Entities.PersonAggregate;

namespace TBC.Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("People", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasOne(x => x.City)
                .WithMany(y => y.People)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PhoneNumbers)
                .WithOne(y => y.Person)
                .HasForeignKey(y => y.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.MainPersonRelatedPeople)
                .WithOne(y => y.MainPerson);

            builder.HasMany(x => x.RelatedPersonRelatedPeople)
                .WithOne(y => y.RelatedPersonn);
        }
    }
}
