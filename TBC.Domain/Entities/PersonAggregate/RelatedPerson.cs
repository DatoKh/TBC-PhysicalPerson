using Common.Domain.Seedwork;
using TBC.Domain.Enums;

namespace TBC.Domain.Entities.PersonAggregate
{
    public class RelatedPerson : BaseEntity<int>
    {
        protected RelatedPerson()
        {

        }

        private RelatedPerson(Person relatedPerson, ContactType contactType)
        {
            RelatedPersonn = relatedPerson;
            ContactType = contactType;
        }

        public virtual Person MainPerson { get; set; }
        public virtual Person RelatedPersonn { get; set; }
        public ContactType ContactType { get; private set; }

        public static RelatedPerson Create(Person relatedPerson, ContactType contactType) => new RelatedPerson(relatedPerson, contactType);

        public void Update(ContactType contactType) => ContactType = contactType;
    }
}
