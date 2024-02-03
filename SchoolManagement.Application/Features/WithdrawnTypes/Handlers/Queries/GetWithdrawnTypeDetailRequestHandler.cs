using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.WithdrawnType;
using SchoolManagement.Application.Features.WithdrawnTypes.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Handlers.Queries
{
    public class GetWithdrawnTypeDetailRequestHandler : IRequestHandler<GetWithdrawnTypeDetailRequest, WithdrawnTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<WithdrawnType> _WithdrawnTypeRepository;
        public GetWithdrawnTypeDetailRequestHandler(ISchoolManagementRepository<WithdrawnType> WithdrawnTypeRepository, IMapper mapper)
        {
            _WithdrawnTypeRepository = WithdrawnTypeRepository;
            _mapper = mapper;
        }
        public async Task<WithdrawnTypeDto> Handle(GetWithdrawnTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var WithdrawnType = await _WithdrawnTypeRepository.Get(request.WithdrawnTypeId);
            return _mapper.Map<WithdrawnTypeDto>(WithdrawnType);
        }
    }
}
