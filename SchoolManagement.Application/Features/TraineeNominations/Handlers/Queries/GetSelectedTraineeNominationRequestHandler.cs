using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetSelectedTraineeNominationRequestHandler : IRequestHandler<GetSelectedTraineeNominationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeNomination> _traineeNominationRepository;


        public GetSelectedTraineeNominationRequestHandler(ISchoolManagementRepository<TraineeNomination> traineeNominationRepository)
        {
            _traineeNominationRepository = traineeNominationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTraineeNominationRequest request, CancellationToken cancellationToken)
        {
            ICollection<TraineeNomination> TraineeNominations = await _traineeNominationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = TraineeNominations.Select(x => new SelectedModel 
            {
                Text = "Trainee Nomination Id = "+x.TraineeNominationId,
                Value = x.TraineeNominationId 
            }).ToList();
            return selectModels;
        }
    }
}
