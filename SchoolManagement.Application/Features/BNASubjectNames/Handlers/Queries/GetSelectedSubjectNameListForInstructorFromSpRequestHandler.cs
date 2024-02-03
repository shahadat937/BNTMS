using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{ 
    public class GetSelectedSubjectNameListForInstructorFromSpRequestHandler : IRequestHandler<GetSelectedSubjectNameListForInstructorFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseInstructor> _courseDurationRepository;

        private readonly IMapper _mapper;
 
        public GetSelectedSubjectNameListForInstructorFromSpRequestHandler(ISchoolManagementRepository<CourseInstructor> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSelectedSubjectNameListForInstructorFromSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetSubjectByTraineeIdForInstructorDashboard] {0},'{1}',{2}", request.TraineeId,request.BaseSchoolNameId,request.CourseDurationId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
