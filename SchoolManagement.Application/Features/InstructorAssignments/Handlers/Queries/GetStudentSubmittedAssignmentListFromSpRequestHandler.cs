using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Queries
{
    public class GetStudentSubmittedAssignmentListFromSpRequestHandler : IRequestHandler<GetStudentSubmittedAssignmentListFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetStudentSubmittedAssignmentListFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetStudentSubmittedAssignmentListFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetTraineeSubmittedAssignmentList] {0},{1},{2},{3},{4}", request.InstructorAssignmentId, request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.BnaSubjectNameId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
