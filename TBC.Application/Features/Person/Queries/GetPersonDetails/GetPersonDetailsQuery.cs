using MediatR;

namespace TBC.Application.Features.Person.Queries.GetPersonDetails
{
    public class GetPersonDetailsQuery : IRequest<PersonDetailsModel>
    {
        public int Id { get; set; }
    }
}
