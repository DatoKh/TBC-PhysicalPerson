using Common.Shared.Base;

namespace TBC.Application.Features.City.Queries.GetCities
{
    public class GetCityModel
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string Name { get; set; }
    }
}
