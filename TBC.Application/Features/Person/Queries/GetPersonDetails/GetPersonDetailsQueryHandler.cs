using AutoMapper;
using Common.Shared.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TBC.Application.Infrastructure.Services;
using TBC.Common.Resources;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Person.Queries.GetPersonDetails
{
    public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetailsModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public GetPersonDetailsQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<PersonDetailsModel> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.PersonRepository.GetSingleAsync(x => x.Id == request.Id && x.IsActive);//.FirstOrDefault();

            if(person == null)
            {
                throw new NotFoundException(StringResource.Person, StringResource.Id, request.Id);
            }

            var personModel = _mapper.Map<PersonDetailsModel>(person);
            personModel.File = await _fileService.Download(person.Image);

            return personModel;
        }
    }
}
