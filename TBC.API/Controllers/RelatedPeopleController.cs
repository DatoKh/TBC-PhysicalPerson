using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TBC.Application.Features.Person.Commands.AddRelatedPerson;
using TBC.Application.Features.Person.Commands.DeletePerson;
using TBC.Application.Features.Person.Queries.GetRelatedPeopleReport;

namespace TBC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedPeopleController
    {
        public readonly IMapper _mapper;
        public IMediator _mediator;

        /// <summary>
        /// Related Person Controller
        /// </summary>
        public RelatedPeopleController(
            IMapper mapper, 
            IMediator mediator
            )
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Create Related Person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost(Name = nameof(CreatePersonsRelationship))]
        public async Task<Unit> CreatePersonsRelationship([FromBody] AddRelatedPersonModel request) =>
            await _mediator.Send(_mapper.Map<AddRelatedPersonCommand>(request));


        /// <summary>
        /// Delete Related Person
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete(Name = nameof(DeletePersonsRelationship))]
        public async Task<Unit> DeletePersonsRelationship([FromQuery] DeletePersonCommand query) =>
            await _mediator.Send(query);


        /// <summary>
        /// Get Person Relationship Report
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = nameof(GetPersonRelationshipReport))]
        public async Task<IEnumerable<RelatedPeopleModel>> GetPersonRelationshipReport(CancellationToken cancellationToken) =>
            await _mediator.Send(new GetRelatedPeopleQuery(), cancellationToken);
    }
}
