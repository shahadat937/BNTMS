using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetTotalMarkAndPassMarkFromSubjectByCourseNameIdSubjectNameIdSpRequestHandler : IRequestHandler<GetTotalMarkAndPassMarkFromSubjectByCourseNameIdSubjectNameIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetTotalMarkAndPassMarkFromSubjectByCourseNameIdSubjectNameIdSpRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
        {
            _bnaSubjectNameRepository = bnaSubjectNameRepository;
            _mapper = mapper;
        }
          
        public async Task<object> Handle(GetTotalMarkAndPassMarkFromSubjectByCourseNameIdSubjectNameIdSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTotalMarkAndPassMarkFromSubjectByCourseNameIdAndSubjectNameIdRequest] {0},{1}", request.CourseNameId, request.BnaSubjectNameId);

            DataTable dataTable = _bnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
