using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetInstructorByBaseSchoolAndCourseNameSpRequestHandler : IRequestHandler<GetInstructorByBaseSchoolAndCourseNameSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseInstructor> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetInstructorByBaseSchoolAndCourseNameSpRequestHandler(ISchoolManagementRepository<CourseInstructor> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetInstructorByBaseSchoolAndCourseNameSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTraineeByCourseNameIdAndBaseSchoolId] {0}, {1}, {2}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
