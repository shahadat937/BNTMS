using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Queries
{
    public class GetTraineeAttendanceListForSchoolIdSpRequestHandler : IRequestHandler<GetTraineeAttendanceListForSchoolIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Attendance> _AttendanceRepository;

        private readonly IMapper _mapper;

        public GetTraineeAttendanceListForSchoolIdSpRequestHandler(ISchoolManagementRepository<Attendance> AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeAttendanceListForSchoolIdSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetTraineeAbsentList] '{0}', {1}", request.CurrentDate, request.BaseSchoolNameId);
            
            DataTable dataTable = _AttendanceRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
