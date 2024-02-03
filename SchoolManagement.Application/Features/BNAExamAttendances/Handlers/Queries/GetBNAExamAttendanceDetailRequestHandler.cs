using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamAttendance;
using SchoolManagement.Application.Features.BnaExamAttendances.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Handlers.Queries
{
    public class GetBnaExamAttendanceDetailRequestHandler : IRequestHandler<GetBnaExamAttendanceDetailRequest, BnaExamAttendanceDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaExamAttendance> _BnaExamAttendanceRepository;
        public GetBnaExamAttendanceDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaExamAttendance> BnaExamAttendanceRepository, IMapper mapper)
        {
            _BnaExamAttendanceRepository = BnaExamAttendanceRepository;
            _mapper = mapper;
        }
        public async Task<BnaExamAttendanceDto> Handle(GetBnaExamAttendanceDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaExamAttendance = await _BnaExamAttendanceRepository.FindOneAsync(x => x.BnaExamAttendanceId == request.BnaExamAttendanceId);
            return _mapper.Map<BnaExamAttendanceDto>(BnaExamAttendance);
        }
    }
}
