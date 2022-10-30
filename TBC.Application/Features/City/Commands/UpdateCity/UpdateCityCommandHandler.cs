using Common.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCityCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            if(await _unitOfWork.CityRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.IsActive))
            {
                throw new AlreadyExistsException(StringResource.City, StringResource.Name, request.Name);
            }

            var city = await _unitOfWork.CityRepository.GetSingleAsync(x => x.Id == request.Id && x.IsActive);

            if(city == null)
            {
                throw new NotFoundException(StringResource.City, StringResource.Id, request.Id);
            }    

            city.Update(request.Name);

            _unitOfWork.CityRepository.Update(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
