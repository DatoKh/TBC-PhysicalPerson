using MediatR;

namespace TBC.Application.Features.Person.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonCommand : IRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}
