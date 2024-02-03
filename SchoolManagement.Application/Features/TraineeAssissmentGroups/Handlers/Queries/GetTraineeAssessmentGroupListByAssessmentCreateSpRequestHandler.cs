using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeAssessmentGroups.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeAssessmentGroups.Handlers.Queries
{
    public class GetTraineeAssessmentGroupListByAssessmentCreateSpRequestHandler : IRequestHandler<GetTraineeAssessmentGroupListByAssessmentCreateSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassPeriod> _classPeriodRepository;

        private readonly IMapper _mapper;

        public GetTraineeAssessmentGroupListByAssessmentCreateSpRequestHandler(ISchoolManagementRepository<ClassPeriod> classPeriodRepository, IMapper mapper)
        {
            _classPeriodRepository = classPeriodRepository;
            _mapper = mapper;
        }
          
        public async Task<object> Handle(GetTraineeAssessmentGroupListByAssessmentCreateSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetTraineeAssessmentGroupListbyAssessment] {0}, {1}, '{2}'", request.CourseDurationId, request.TraineeAssessmentCreateId, request.SearchText);
            
            DataTable dataTable = _classPeriodRepository.ExecWithSqlQuery(spQuery);
            
            return dataTable;
         
        }
    }
}
