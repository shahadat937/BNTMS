using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetJcoExamResultBySubjectSpRequestHandler : IRequestHandler<GetJcoExamResultBySubjectSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetJcoExamResultBySubjectSpRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
        {
            _bnaSubjectNameRepository = bnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetJcoExamResultBySubjectSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetJcosSubjectResult] {0},{1},{2}", request.CourseDurationId, request.BnaSubjectNameId, request.ResultStatus);

            DataTable dataTable = _bnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
