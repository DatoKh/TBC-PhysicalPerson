using FluentValidation;

namespace TBC.Application.Features.Person.Commands.AddPersonContact
{
    public class AddPersonContactCommandValidator : AbstractValidator<AddPersonContactCommand>
    {
        public AddPersonContactCommandValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
            RuleFor(x => x.PhoneNumberType).NotEmpty();

            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(4).MaximumLength(50);
        }
    }
}
