using Common.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Application.Infrastructure.Services;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Person.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public UpdatePersonCommandHandler(
            IUnitOfWork unitOfWork, 
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            if(!(await _unitOfWork.PersonRepository.AnyAsync(x => x.Id == request.Id && x.IsActive)))
            {
                throw new NotFoundException(StringResource.Person, StringResource.PersonalNumber, request.PersonalNumber);
            }

            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.Id && x.IsActive);

            person.Update(request.PersonalNumber, request.FirstName, request.LastName, request.Gender, request.BirthDate, request.CityId);

            person.ChangeImage(request.Image == null ? person.Image : await _fileService.Upload(request.Image));

            _unitOfWork.PersonRepository.Update(person);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
