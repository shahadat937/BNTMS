using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models; 

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetSelectedTraineeNominationByCourseDurationIdRequestHandler : IRequestHandler<GetSelectedTraineeNominationByCourseDurationIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeNomination> _TraineeNominationRepository;


        public GetSelectedTraineeNominationByCourseDurationIdRequestHandler(ISchoolManagementRepository<TraineeNomination> TraineeNominationRepository)
        {
            _TraineeNominationRepository = TraineeNominationRepository;
        }
         
        public async Task<List<SelectedModel>> Handle(GetSelectedTraineeNominationByCourseDurationIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<TraineeNomination> codeValues = _TraineeNominationRepository.FilterWithInclude(x => x.CourseDurationId == request.CourseDurationId, "Trainee");
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Trainee.Pno+"_"+x.Trainee.Name,
                Value = x.TraineeId
            }).ToList();
            return selectModels;
        }
    }
}
