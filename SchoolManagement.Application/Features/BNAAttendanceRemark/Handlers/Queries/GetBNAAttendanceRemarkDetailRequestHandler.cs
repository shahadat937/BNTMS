using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks;
using SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Handlers.Queries
{
    public class GetBnaAttendanceRemarkDetailRequestHandler : IRequestHandler<GetBnaAttendanceRemarkDetailRequest, BnaAttendanceRemarkDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BnaAttendanceRemarks> _BnaAttendanceRemarkRepository;
        public GetBnaAttendanceRemarkDetailRequestHandler(ISchoolManagementRepository<BnaAttendanceRemarks> BnaAttendanceRemarkRepository, IMapper mapper)
        {
            _BnaAttendanceRemarkRepository = BnaAttendanceRemarkRepository;
            _mapper = mapper;
        }
        public async Task<BnaAttendanceRemarkDto> Handle(GetBnaAttendanceRemarkDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaAttendanceRemark = await _BnaAttendanceRemarkRepository.Get(request.BnaAttendanceRemarksId);
            return _mapper.Map<BnaAttendanceRemarkDto>(BnaAttendanceRemark);
        }
    }
}
