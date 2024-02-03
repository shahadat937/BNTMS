using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses;
using SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Handlers.Queries
{
    public class GetBnaClassScheduleStatusDetailRequestHandler : IRequestHandler<GetBnaClassScheduleStatusDetailRequest, BnaClassScheduleStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BnaClassScheduleStatus> _BnaClassScheduleStatusRepository;
        public GetBnaClassScheduleStatusDetailRequestHandler(ISchoolManagementRepository<BnaClassScheduleStatus> BnaClassScheduleStatusRepository, IMapper mapper)
        {
            _BnaClassScheduleStatusRepository = BnaClassScheduleStatusRepository;
            _mapper = mapper;
        }
        public async Task<BnaClassScheduleStatusDto> Handle(GetBnaClassScheduleStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaClassScheduleStatus = await _BnaClassScheduleStatusRepository.Get(request.BnaClassScheduleStatusId);
            return _mapper.Map<BnaClassScheduleStatusDto>(BnaClassScheduleStatus);
        }
    }
}
