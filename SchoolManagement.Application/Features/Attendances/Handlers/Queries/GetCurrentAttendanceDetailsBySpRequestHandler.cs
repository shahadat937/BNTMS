using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Queries
{
    public class GetCurrentAttendanceDetailsBySpRequestHandler : IRequestHandler<GetCurrentAttendanceDetailsBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<Attendance> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetCurrentAttendanceDetailsBySpRequestHandler(ISchoolManagementRepository<Attendance> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCurrentAttendanceDetailsBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetAttendanceForTodaySchoolDashboard] '{0}',{1}, {2}, {3}", request.CurrentDate,request.CourseNameId,request.BaseSchoolNameId, request.CourseDurationId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
