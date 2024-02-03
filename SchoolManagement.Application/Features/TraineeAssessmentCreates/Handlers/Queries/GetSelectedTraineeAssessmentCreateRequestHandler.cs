using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Handlers.Queries
{ 
    public class GetSelectedTraineeAssessmentCreateRequestHandler : IRequestHandler<GetSelectedTraineeAssessmentCreateRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeAssessmentCreate> _TraineeAssessmentCreateRepository;


        public GetSelectedTraineeAssessmentCreateRequestHandler(ISchoolManagementRepository<TraineeAssessmentCreate> TraineeAssessmentCreateRepository)
        {
            _TraineeAssessmentCreateRepository = TraineeAssessmentCreateRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTraineeAssessmentCreateRequest request, CancellationToken cancellationToken)
        {
            ICollection<TraineeAssessmentCreate> TraineeAssessmentCreates = await _TraineeAssessmentCreateRepository.FilterAsync(x => x.CourseDurationId == request.CourseDurationId && x.Status == 0);
            List<SelectedModel> selectModels = TraineeAssessmentCreates.Select(x => new SelectedModel 
            {
                Text = x.AssessmentName,
                Value = x.TraineeAssessmentCreateId
            }).ToList();
            return selectModels;
        }
    }
}
