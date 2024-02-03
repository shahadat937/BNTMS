using AutoMapper;
using SchoolManagement.Application.DTOs.FailureStatus;
using SchoolManagement.Application.Features.FailureStatuses.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FailureStatuses.Handlers.Queries
{
    public class GetFailureStatusDetailRequestHandler : IRequestHandler<GetFailureStatusDetailRequest, FailureStatusDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FailureStatus> _FailureStatusRepository;
        public GetFailureStatusDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.FailureStatus> FailureStatusRepository, IMapper mapper)
        {
            _FailureStatusRepository = FailureStatusRepository;
            _mapper = mapper;
        }
        public async Task<FailureStatusDto> Handle(GetFailureStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var FailureStatus = await _FailureStatusRepository.Get(request.FailureStatusId);
            return _mapper.Map<FailureStatusDto>(FailureStatus);
        }
    }
}
