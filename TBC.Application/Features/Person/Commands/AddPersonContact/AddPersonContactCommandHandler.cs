using Common.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Common.Resources;
using TBC.Domain.Entities.PersonAggregate;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Person.Commands.AddPersonContact
{
    public class AddPersonContactCommandHandler : IRequestHandler<AddPersonContactCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPersonContactCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddPersonContactCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.PersonId && x.IsActive);

            if (person == null)
            {
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.PersonId);
            }

            person.AddPhoneNumber(PhoneNumber.Create(request.PhoneNumber, request.PhoneNumberType));

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
