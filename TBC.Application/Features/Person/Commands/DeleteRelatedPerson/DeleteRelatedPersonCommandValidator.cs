using FluentValidation;

namespace TBC.Application.Features.Person.Commands.DeleteRelatedPerson
{
    class DeleteRelatedPersonCommandValidator : AbstractValidator<DeleteRelatedPersonCommand>
    {
        public DeleteRelatedPersonCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.RelatedPersonId).NotEmpty();
        }
    }
}
