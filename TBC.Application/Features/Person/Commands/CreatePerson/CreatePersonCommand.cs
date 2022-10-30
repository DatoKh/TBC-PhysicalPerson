using Common.Shared.Mapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : MapFrom<CreatePersonModel>, IRequest<int>
    {
        public string PersonalNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public IFormFile Image { get; set; }
        public int CityId { get; set; }
    }
}
