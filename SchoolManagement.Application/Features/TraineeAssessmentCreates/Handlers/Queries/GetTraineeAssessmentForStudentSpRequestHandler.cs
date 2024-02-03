using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Handlers.Queries
{
    public class GetTraineeAssessmentForStudentSpRequestHandler : IRequestHandler<GetTraineeAssessmentForStudentSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassPeriod> _classPeriodRepository;

        private readonly IMapper _mapper;

        public GetTraineeAssessmentForStudentSpRequestHandler(ISchoolManagementRepository<ClassPeriod> classPeriodRepository, IMapper mapper)
        {
            _classPeriodRepository = classPeriodRepository;
            _mapper = mapper;
        }
          
        public async Task<object> Handle(GetTraineeAssessmentForStudentSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetTraineeAssessmentListForStudent] {0}, {1},'{2}'", request.CourseDurationId, request.TraineeId, request.CurrentDate);
            
            DataTable dataTable = _classPeriodRepository.ExecWithSqlQuery(spQuery);
            
            return dataTable;
         
        }
    }
}
