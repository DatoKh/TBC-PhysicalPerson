using AutoMapper;
using Common.Shared.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.City.Queries.GetCities
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, PagedList<CityModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCityQueryHandler(
            IUnitOfWork unitOfWork, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PagedList<CityModel>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var cities =  _unitOfWork.CityRepository.GetAll(new CitySpecification(request).ToExpression());

            var pagedList = await PagedList<Domain.Entities.CityAggregate.City>.Create(_unitOfWork.CityRepository, cities, request.PageNumber, request.PageSize, _mapper, cancellationToken);

            return _mapper.Map<PagedList<CityModel>>(pagedList);
        }
    }
}
