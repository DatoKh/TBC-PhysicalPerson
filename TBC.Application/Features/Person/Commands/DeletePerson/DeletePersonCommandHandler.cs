using Common.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Person.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            if(!(await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == request.Id && x.IsActive)))
            {
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.Id);
            }

            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.Id && x.IsActive);

            person.Delete();

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
