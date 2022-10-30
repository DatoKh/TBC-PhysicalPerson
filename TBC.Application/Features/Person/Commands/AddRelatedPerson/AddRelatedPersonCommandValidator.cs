using FluentValidation;

namespace TBC.Application.Features.Person.Commands.AddRelatedPerson
{
    public class AddRelatedPersonCommandValidator : AbstractValidator<AddRelatedPersonCommand>
    {
        public AddRelatedPersonCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.RelatedPersonId).NotEmpty();
            RuleFor(x => x.ContactType).NotEmpty();
        }
    }
}
