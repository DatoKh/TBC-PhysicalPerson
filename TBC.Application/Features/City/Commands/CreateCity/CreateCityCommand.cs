using Common.Shared.Mapper;
using MediatR;

namespace TBC.Application.Features.City.Commands.CreateCity
{
    public class CreateCityCommand : MapFrom<CreateCityModel>, IRequest<int>
    {
        public string Name { get; set; }
    }

}
