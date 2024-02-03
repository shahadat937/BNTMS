using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod;
using SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Queries;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Handlers.Queries
{
    public class GetBnaAttendancePeriodDetailRequestHandler: IRequestHandler<GetBnaAttendancePeriodDetailRequest, BnaAttendancePeriodDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaAttendancePeriod> _BnaAttendancePeriodRepository;
        public GetBnaAttendancePeriodDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaAttendancePeriod> BnaAttendancePeriodRepository, IMapper mapper)
        {
            _BnaAttendancePeriodRepository = BnaAttendancePeriodRepository;
            _mapper = mapper;
        }
        public async Task<BnaAttendancePeriodDto> Handle(GetBnaAttendancePeriodDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaAttendancePeriod = await _BnaAttendancePeriodRepository.Get(request.BnaAttendancePeriodId);
            return _mapper.Map<BnaAttendancePeriodDto>(BnaAttendancePeriod);
        }
    }
}
