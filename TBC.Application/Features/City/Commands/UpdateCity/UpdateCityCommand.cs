using MediatR;

namespace TBC.Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
