using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetTodayClassScheduleByCourseInstructorIdSpRequestHandler : IRequestHandler<GetTodayClassScheduleByCourseInstructorIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseInstructor> _routineRepository;

        private readonly IMapper _mapper;

        public GetTodayClassScheduleByCourseInstructorIdSpRequestHandler(ISchoolManagementRepository<CourseInstructor> routineRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTodayClassScheduleByCourseInstructorIdSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTodayClassByInstructorId] {0}", request.TraineeId);
            
            DataTable dataTable = _routineRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
