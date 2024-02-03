using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetTotalMarkAndPassMarkFromSubjectSpRequestHandler : IRequestHandler<GetTotalMarkAndPassMarkFromSubjectSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetTotalMarkAndPassMarkFromSubjectSpRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
        {
            _bnaSubjectNameRepository = bnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetTotalMarkAndPassMarkFromSubjectSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetTotalMarkAndPassMarkFromSubjectByParameterRequest] {0},{1},{2}", request.BaseSchoolNameId, request.CourseNameId, request.BnaSubjectNameId);

            DataTable dataTable = _bnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
