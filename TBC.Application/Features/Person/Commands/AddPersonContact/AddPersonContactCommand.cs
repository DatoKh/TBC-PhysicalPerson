using Common.Shared.Mapper;
using MediatR;
using TBC.Domain.Enums;

namespace TBC.Application.Features.Person.Commands.AddPersonContact
{
    public class AddPersonContactCommand : MapFrom<AddPersonContactModel>, IRequest
    {
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
