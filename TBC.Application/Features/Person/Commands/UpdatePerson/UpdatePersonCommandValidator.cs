using FluentValidation;
using System;
using System.Text.RegularExpressions;
using TBC.Common.Resources;

namespace TBC.Application.Features.Person.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(2, 50)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x) &&
                    (Regex.IsMatch(x, "^[a-zA-Z]*$") || Regex.IsMatch(x, "^[ა-ჰ]*$")))
                .WithMessage(StringResource.TextError);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(2, 50)
                .Must(x =>
                    !string.IsNullOrWhiteSpace(x) &&
                    (Regex.IsMatch(x, "^[a-zA-Z]*$") || Regex.IsMatch(x, "^[ა-ჰ]*$")))
                .WithMessage(StringResource.TextError);

            RuleFor(x => x.PersonalNumber)
                .NotEmpty()
                .Length(11, 11)
                .Matches("^[0-9]*$");

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .Must(b => DateTime.Now.Year - b.Year >= 18).WithMessage("Person is under 18")
                .WithMessage(StringResource.TextError);

            RuleFor(m => m.Gender)
                .NotEmpty();
        }
    }
}
