using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetSelectedInstructorNameByParamsSpRequestHandler : IRequestHandler<GetSelectedInstructorNameByParamsSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseInstructor> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetSelectedInstructorNameByParamsSpRequestHandler(ISchoolManagementRepository<CourseInstructor> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSelectedInstructorNameByParamsSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetInstructorNameForRoutine] {0},{1},{2},{3},{4}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.CourseSectionId, request.BnaSubjectNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
