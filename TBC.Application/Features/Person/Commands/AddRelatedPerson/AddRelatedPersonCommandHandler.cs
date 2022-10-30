using Common.Shared.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Person.Commands.AddRelatedPerson
{
    public class AddRelatedPersonCommandHandler : IRequestHandler<AddRelatedPersonCommand,Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddRelatedPersonCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(AddRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.PersonId && x.IsActive);

            if(person == null)
            {
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.PersonId);
            }

            var relatedPerson = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.RelatedPersonId && x.IsActive);

            if(relatedPerson == null)
            {
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.RelatedPersonId);
            }

            person.AddRelatedPerson(relatedPerson, request.ContactType);

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
