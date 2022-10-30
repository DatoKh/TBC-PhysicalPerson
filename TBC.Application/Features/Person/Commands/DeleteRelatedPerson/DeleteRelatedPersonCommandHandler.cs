using Common.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Person.Commands.DeleteRelatedPerson
{
    public class DeleteRelatedPersonCommandHandler : IRequestHandler<DeleteRelatedPersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRelatedPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.PersonId && x.IsActive);

            if (person == null)
            {
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.PersonId);
            }

            var relatedPerson = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.RelatedPersonId && x.IsActive);

            if (relatedPerson == null)
            {
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.RelatedPersonId);
            }

            person.DeleteRelatedPerson(request.RelatedPersonId);

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
