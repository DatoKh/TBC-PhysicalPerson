using Common.Shared.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.CityRepository.GetSingleAsync(x => x.Id == request.Id && x.IsActive);

            if(city == null)
            {
                throw new NotFoundException(StringResource.City, StringResource.Id, request.Id);
            }

            city.Delete();

            _unitOfWork.CityRepository.Update(city);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
