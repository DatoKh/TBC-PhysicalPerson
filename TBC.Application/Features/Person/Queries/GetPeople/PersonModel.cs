using Common.Shared.Mapper;
using System;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Person.Queries.GetPeople
{
    public class PersonModel : MapFrom<Domain.Entities.PersonAggregate.Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
