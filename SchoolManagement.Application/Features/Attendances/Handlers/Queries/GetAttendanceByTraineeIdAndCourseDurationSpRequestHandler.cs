using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Queries
{
    public class GetAttendanceByTraineeIdAndCourseDurationSpRequestHandler : IRequestHandler<GetAttendanceByTraineeIdAndCourseDurationSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Attendance> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetAttendanceByTraineeIdAndCourseDurationSpRequestHandler(ISchoolManagementRepository<Attendance> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetAttendanceByTraineeIdAndCourseDurationSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetAttendaceByTraineeIdForStudentDashboard] {0}, {1}", request.TraineeId, request.CourseDurationId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
