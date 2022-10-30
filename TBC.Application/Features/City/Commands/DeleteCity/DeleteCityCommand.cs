using MediatR;

namespace TBC.Application.Features.City.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest
    {
        public int Id { get; set; }
    }
}
