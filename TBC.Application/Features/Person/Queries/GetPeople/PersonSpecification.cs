using Common.Shared.Specifications;
using System;
using System.Linq.Expressions;
using TBC.Application.Utilities;

namespace TBC.Application.Features.Person.Queries.GetPeople
{
    public class PersonSpecification : Specification<Domain.Entities.PersonAggregate.Person>
    {
        private Expression<Func<Domain.Entities.PersonAggregate.Person, bool>> BaseExpression { get; set; } = u => u.IsActive;

        private readonly GetPeopleQuery _filter;

        public PersonSpecification(GetPeopleQuery filter)
        {
            _filter = filter;
        }

        public override Expression<Func<Domain.Entities.PersonAggregate.Person, bool>> ToExpression()
        {
            var result = BaseExpression;

            if (!string.IsNullOrWhiteSpace(_filter.PersonalNumber))
            {
                result = result.And(e => e.PersonalNumber.Contains(_filter.PersonalNumber));
            }

            if (!string.IsNullOrWhiteSpace(_filter.FirstName))
            {
                result = result.And(e => e.Name.ToLower().Contains(_filter.FirstName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(_filter.LastName))
            {
                result = result.And(e => e.Lastname.ToLower().Contains(_filter.LastName.ToLower()));
            }

            if (_filter.Gender != 0)
            {
                result = result.And(e => e.Gender == _filter.Gender);
            }

            return result;
        }
    }
}
