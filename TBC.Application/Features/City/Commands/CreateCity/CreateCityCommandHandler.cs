using Common.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCityCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            if(await _unitOfWork.CityRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.IsActive))
            {
                throw new AlreadyExistsException(StringResource.City, StringResource.Name, request.Name);
            }

            var city = Domain.Entities.CityAggregate.City.Create(request.Name);

            await _unitOfWork.CityRepository.AddAsync(city);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}
