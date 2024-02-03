using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetInstructorBySchoolForCOSpRequestHandler : IRequestHandler<GetInstructorBySchoolForCOSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseInstructor> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetInstructorBySchoolForCOSpRequestHandler(ISchoolManagementRepository<CourseInstructor> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetInstructorBySchoolForCOSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetInstructorBySchoolForCODashboard] {0}", request.BaseNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
