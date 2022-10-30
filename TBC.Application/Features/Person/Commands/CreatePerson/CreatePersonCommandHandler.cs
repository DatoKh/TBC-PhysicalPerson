using Common.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Application.Infrastructure.Services;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _flieService;
        public CreatePersonCommandHandler(
            IUnitOfWork unitOfWork,
            IFileService flieService)
        {
            _unitOfWork = unitOfWork;
            _flieService = flieService;
        }
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            if((await _unitOfWork.PersonRepository.AnyAsync(x => x.PersonalNumber == request.PersonalNumber && x.IsActive)))
            {
                throw new AlreadyExistsException(StringResource.Person, StringResource.PersonalNumber, request.PersonalNumber);
            }

            var filePath = await _flieService.Upload(request.Image);

            var person = Domain.Entities.PersonAggregate.Person.Create(request.PersonalNumber, request.FirstName, request.LastName, request.Gender, request.BirthDate, filePath, request.CityId);

            await _unitOfWork.PersonRepository.AddAsync(person);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return person.Id;
        }
    }
}
