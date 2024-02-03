using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetExamStatusBySubjectListSpRequestHandler : IRequestHandler<GetExamStatusBySubjectListSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetExamStatusBySubjectListSpRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
        {
            _bnaSubjectNameRepository = bnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetExamStatusBySubjectListSpRequest request, CancellationToken cancellationToken)
        {

            var spQuery = String.Format("exec [spGetExamStatesBySubjectList] {0}", request.CourseDurationId);

            DataTable dataTable = _bnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
