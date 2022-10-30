using Common.Shared.Mapper;

namespace TBC.Application.Features.City.Queries.GetCities
{
    public class CityModel : MapFrom<Domain.Entities.CityAggregate.City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
