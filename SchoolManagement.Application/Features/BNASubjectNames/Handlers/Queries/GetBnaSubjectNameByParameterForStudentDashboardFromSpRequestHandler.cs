using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetBnaSubjectNameByParameterForStudentDashboardFromSpRequestHandler : IRequestHandler<GetBnaSubjectNameByParameterForStudentDashboardFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetBnaSubjectNameByParameterForStudentDashboardFromSpRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
        {
            _bnaSubjectNameRepository = bnaSubjectNameRepository;
            _mapper = mapper;
        }
         
        public async Task<object> Handle(GetBnaSubjectNameByParameterForStudentDashboardFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetSubjectByModuleForStudentDashboard] {0},{1},{2}", request.BaseSchoolNameId, request.CourseNameId, request.CourseModuleId);
            
            DataTable dataTable = _bnaSubjectNameRepository.ExecWithSqlQuery(spQuery);
            

            return dataTable;
         
        }
    }
}
