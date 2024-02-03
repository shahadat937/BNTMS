using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.InterServiceCourseReports.Handlers.Queries
{
    public class GetInterServiceCourseReportDetailRequestHandler : IRequestHandler<GetInterServiceCourseReportDetailRequest, InterServiceCourseReportDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.InterServiceCourseReport> _InterServiceCourseReportRepository;
        public GetInterServiceCourseReportDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.InterServiceCourseReport> InterServiceCourseReportRepository, IMapper mapper)
        {
            _InterServiceCourseReportRepository = InterServiceCourseReportRepository;
            _mapper = mapper;
        }
        public async Task<InterServiceCourseReportDto> Handle(GetInterServiceCourseReportDetailRequest request, CancellationToken cancellationToken)
        {
            var InterServiceCourseReport = await _InterServiceCourseReportRepository.Get(request.InterServiceCourseReportid);
            return _mapper.Map<InterServiceCourseReportDto>(InterServiceCourseReport);
        }
    }
}
