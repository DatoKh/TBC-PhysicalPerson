using Common.Shared.Base;
using Common.Shared.Mapper;
using MediatR;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Person.Queries.GetPeople
{
    public class GetPeopleQuery : MapFrom<GetPeopleModel>, IRequest<PagedList<PersonModel>>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}
