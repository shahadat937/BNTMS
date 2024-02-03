using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TrainingObjectives.Handlers.Queries
{
    public class GetSelectedTrainingObjectiveRequestHandler : IRequestHandler<GetSelectedTrainingObjectiveRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TrainingObjective> _TrainingObjectiveRepository;


        public GetSelectedTrainingObjectiveRequestHandler(ISchoolManagementRepository<TrainingObjective> TrainingObjectiveRepository)
        {
            _TrainingObjectiveRepository = TrainingObjectiveRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTrainingObjectiveRequest request, CancellationToken cancellationToken)
        {
            ICollection<TrainingObjective> codeValues = await _TrainingObjectiveRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.TrainingObjectDetail,
                Value = x.TrainingObjectiveId
            }).ToList();
            return selectModels;
        }
    }
}
