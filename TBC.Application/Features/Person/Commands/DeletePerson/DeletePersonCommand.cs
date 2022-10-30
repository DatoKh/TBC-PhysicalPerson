using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TBC.Application.Features.Person.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public int Id { get; set; }
    }
}
