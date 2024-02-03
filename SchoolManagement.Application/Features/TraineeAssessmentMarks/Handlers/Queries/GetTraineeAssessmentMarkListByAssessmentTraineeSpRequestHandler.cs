using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Handlers.Queries
{
    public class GetTraineeAssessmentMarkListByAssessmentTraineeSpRequestHandler : IRequestHandler<GetTraineeAssessmentMarkListByAssessmentTraineeSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeAssessmentMark> _TraineeAssessmentMarkRepository;

        private readonly IMapper _mapper;

        public GetTraineeAssessmentMarkListByAssessmentTraineeSpRequestHandler(ISchoolManagementRepository<TraineeAssessmentMark> TraineeAssessmentMarkRepository, IMapper mapper)
        {
            _TraineeAssessmentMarkRepository = TraineeAssessmentMarkRepository;
            _mapper = mapper;
        }
          
        public async Task<object> Handle(GetTraineeAssessmentMarkListByAssessmentTraineeSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetTraineeAssessmentMarkListByTrainee] {0}, {1}, {2}", request.CourseDurationId, request.TraineeAssessmentCreateId, request.AssessmentTraineeId);
            
            DataTable dataTable = _TraineeAssessmentMarkRepository.ExecWithSqlQuery(spQuery);
            
            return dataTable;
         
        }
    }
}
