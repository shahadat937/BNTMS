using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Handlers.Queries
{
    public class GetSelectedTraineeAssignmentSubmitRequestHandler : IRequestHandler<GetSelectedTraineeAssignmentSubmitRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TraineeAssignmentSubmit> _TraineeAssignmentSubmitRepository;


        public GetSelectedTraineeAssignmentSubmitRequestHandler(ISchoolManagementRepository<TraineeAssignmentSubmit> TraineeAssignmentSubmitRepository)
        {
            _TraineeAssignmentSubmitRepository = TraineeAssignmentSubmitRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTraineeAssignmentSubmitRequest request, CancellationToken cancellationToken)
        {
            ICollection<TraineeAssignmentSubmit> codeValues = await _TraineeAssignmentSubmitRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AssignmentTopic,
                Value = x.TraineeAssignmentSubmitId
            }).ToList();
            return selectModels;
        }
    }
}
