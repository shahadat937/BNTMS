using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Queries
{
    public class GetSelectedClassPeriodForAttendanceInstructorSpRequestHandler : IRequestHandler<GetSelectedClassPeriodForAttendanceInstructorSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassPeriod> _classPeriodRepository;

        private readonly IMapper _mapper;

        public GetSelectedClassPeriodForAttendanceInstructorSpRequestHandler(ISchoolManagementRepository<ClassPeriod> classPeriodRepository, IMapper mapper)
        {
            _classPeriodRepository = classPeriodRepository;
            _mapper = mapper;
        }
          
        public async Task<object> Handle(GetSelectedClassPeriodForAttendanceInstructorSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetClassAttendanceByInstructorDashboard] '{0}',{1}", request.CurrentDate, request.TraineeId);
            
            DataTable dataTable = _classPeriodRepository.ExecWithSqlQuery(spQuery);
            

            return dataTable;
         
        }
    }
}
