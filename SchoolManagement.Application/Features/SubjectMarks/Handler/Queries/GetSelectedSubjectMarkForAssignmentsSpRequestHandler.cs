using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.SubjectMarks.Handlers.Queries
{
    public class GetSelectedSubjectMarkForAssignmentsSpRequestHandler : IRequestHandler<GetSelectedSubjectMarkForAssignmentsSpRequest, object>
    {

        private readonly ISchoolManagementRepository<SubjectMark> _SubjectMarkRepository;

        private readonly IMapper _mapper;

        public GetSelectedSubjectMarkForAssignmentsSpRequestHandler(ISchoolManagementRepository<SubjectMark> SubjectMarkRepository, IMapper mapper)
        {
            _SubjectMarkRepository = SubjectMarkRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSelectedSubjectMarkForAssignmentsSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetMarkTypeForAssignments] {0},{1},{2}", request.CourseNameId, request.BaseSchoolNameId,request.BnaSubjectNameId);
            
            DataTable dataTable = _SubjectMarkRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
