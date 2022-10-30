using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TBC.Application.Features.Person.Commands.AddPersonContact;

namespace TBC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonContactController
    {
        public readonly IMapper _mapper;
        public IMediator _mediator;

        public PersonContactController(
            IMapper mapper, 
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Create Person Phone
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(CreatePersonContact))]
        public async Task<Unit> CreatePersonContact([FromBody] AddPersonContactModel request) =>
            await _mediator.Send(_mapper.Map<AddPersonContactCommand>(request));

    }
}
