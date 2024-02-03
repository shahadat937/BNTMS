using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Queries
{
    public class GetCurrentAttendanceDetailsByRoutineSpRequestHandler : IRequestHandler<GetCurrentAttendanceDetailsByRoutineSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Attendance> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetCurrentAttendanceDetailsByRoutineSpRequestHandler(ISchoolManagementRepository<Attendance> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCurrentAttendanceDetailsByRoutineSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetTodayAttendanceDetailSchoolDashboard] {0},{1},{2},{3}", request.CourseNameId,request.BaseSchoolNameId, request.CourseDurationId, request.ClassRoutineId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
