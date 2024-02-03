using AutoMapper;
using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Queries
{
    public class GetAttendanceDetailRequestHandler : IRequestHandler<GetAttendanceDetailRequest, AttendanceDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Attendance> _AttendanceRepository;
        public GetAttendanceDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Attendance> AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
        }
        public async Task<AttendanceDto> Handle(GetAttendanceDetailRequest request, CancellationToken cancellationToken)
        {
            var Attendance = await _AttendanceRepository.FindOneAsync(x => x.AttendanceId == request.AttendanceId);
            return _mapper.Map<AttendanceDto>(Attendance);
        }
    }
}
