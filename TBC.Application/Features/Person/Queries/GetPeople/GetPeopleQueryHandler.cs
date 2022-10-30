using AutoMapper;
using Common.Shared.Base;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TBC.Domain.SeedWork;

namespace TBC.Application.Features.Person.Queries.GetPeople
{
    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, PagedList<PersonModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPeopleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<PersonModel>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            var data = _unitOfWork.PersonRepository.GetAll(new PersonSpecification(request).ToExpression());

            return await PagedList<PersonModel>.Create(_unitOfWork.PersonRepository, data, request.PageNumber, request.PageSize, _mapper, cancellationToken);
        }
    }
}
