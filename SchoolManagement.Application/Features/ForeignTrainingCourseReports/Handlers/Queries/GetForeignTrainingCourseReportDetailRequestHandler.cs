using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
using SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ForeignTrainingCourseReports.Handlers.Queries
{
    public class GetForeignTrainingCourseReportDetailRequestHandler : IRequestHandler<GetForeignTrainingCourseReportDetailRequest, ForeignTrainingCourseReportDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignTrainingCourseReport> _ForeignTrainingCourseReportRepository;
        public GetForeignTrainingCourseReportDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignTrainingCourseReport> ForeignTrainingCourseReportRepository, IMapper mapper)
        {
            _ForeignTrainingCourseReportRepository = ForeignTrainingCourseReportRepository;
            _mapper = mapper;
        }
        public async Task<ForeignTrainingCourseReportDto> Handle(GetForeignTrainingCourseReportDetailRequest request, CancellationToken cancellationToken)
        {
            var ForeignTrainingCourseReport = await _ForeignTrainingCourseReportRepository.Get(request.ForeignTrainingCourseReportid);
            return _mapper.Map<ForeignTrainingCourseReportDto>(ForeignTrainingCourseReport);
        }
    }
}
