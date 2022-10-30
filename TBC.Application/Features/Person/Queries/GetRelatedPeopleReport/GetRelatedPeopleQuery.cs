using MediatR;
using System.Collections.Generic;

namespace TBC.Application.Features.Person.Queries.GetRelatedPeopleReport
{
    public class GetRelatedPeopleQuery : IRequest<IEnumerable<RelatedPeopleModel>>
    {
    }
}
