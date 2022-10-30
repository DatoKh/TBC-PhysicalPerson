using TBC.Domain.Enums;

namespace TBC.Application.Features.Person.Commands.AddRelatedPerson
{
    public class AddRelatedPersonModel
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public ContactType ContactType { get; set; }
    }
}
