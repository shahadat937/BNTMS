using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.InstructorAssignments.Handlers.Queries
{
    public class GetStudentAssignmentListFromSpRequestHandler : IRequestHandler<GetStudentAssignmentListFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetStudentAssignmentListFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetStudentAssignmentListFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetAssignmentForStudent] '{0}',{1},{2},{3}", request.CurrentDate, request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
