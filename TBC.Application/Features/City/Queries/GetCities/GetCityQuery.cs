using Common.Shared.Base;
using Common.Shared.Mapper;
using MediatR;

namespace TBC.Application.Features.City.Queries.GetCities
{
    public class GetCityQuery : MapFrom<GetCityModel>, IRequest<PagedList<CityModel>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string Name { get; set; }
    }
}
