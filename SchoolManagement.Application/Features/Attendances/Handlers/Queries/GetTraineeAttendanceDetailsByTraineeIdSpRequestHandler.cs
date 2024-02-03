using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Queries
{
    public class GetTraineeAttendanceDetailsByTraineeIdSpRequestHandler : IRequestHandler<GetTraineeAttendanceDetailsByTraineeIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Attendance> _AttendanceRepository;

        private readonly IMapper _mapper;

        public GetTraineeAttendanceDetailsByTraineeIdSpRequestHandler(ISchoolManagementRepository<Attendance> AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeAttendanceDetailsByTraineeIdSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetTraineeAbsentDetails] {0}", request.TraineeId);
            
            DataTable dataTable = _AttendanceRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
