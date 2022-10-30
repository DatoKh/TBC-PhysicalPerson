using AutoMapper;
using Common.Shared.Mapper;
using System;
using System.Collections.Generic;
using TBC.Domain.Entities.PersonAggregate;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Person.Queries.GetPersonDetails
{
    public class PersonDetailsModel : MapFrom<Domain.Entities.PersonAggregate.Person>
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; } 
        public string PersonalNumber { get; set; } 
        public DateTime BirthDate { get; set; } 
        public string City { get; set; } 
        public Gender Gender { get; set; } 
        public byte[] File { get; set; } 
        public IEnumerable<PhoneModel> PhoneNumbers { get; set; }

        public IEnumerable<RelatedPersonModel> MainPersonRelatedPeople { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.PersonAggregate.Person, PersonDetailsModel>()
                .ForMember(x => x.City, m => m.MapFrom(t => t.City.Name));
        }
    }


    public class PhoneModel : MapFrom<PhoneNumber>
    {
        public int Id { get; set; }
        public string Phone { get; set; }
    }

    public class RelatedPersonModel : MapFrom<RelatedPerson>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }

        public new void Mapping(Profile profile)
        {
            profile.CreateMap<RelatedPerson, RelatedPersonModel>()
                .ForMember(x => x.Id, m => m.MapFrom(t => t.RelatedPersonn.Id))
                .ForMember(x => x.Name, m => m.MapFrom(t => t.RelatedPersonn.Name))
                .ForMember(x => x.LastName, m => m.MapFrom(t => t.RelatedPersonn.Lastname))
                .ForMember(x => x.PersonalNumber, m => m.MapFrom(t => t.RelatedPersonn.PersonalNumber))
                .ForMember(x => x.BirthDate, m => m.MapFrom(t => t.RelatedPersonn.BirthDate))
                .ForMember(x => x.City, m => m.MapFrom(t => t.RelatedPersonn.City.Name))
                .ForMember(x => x.Gender, m => m.MapFrom(t => t.RelatedPersonn.Gender));
        }
    }
}
