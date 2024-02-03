using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Weights.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Weights.Handlers.Queries
{ 
    public class GetSelectedWeightRequestHandler : IRequestHandler<GetSelectedWeightRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Weight> _WeightRepository;


        public GetSelectedWeightRequestHandler(ISchoolManagementRepository<Weight> WeightRepository)
        {
            _WeightRepository = WeightRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedWeightRequest request, CancellationToken cancellationToken)
        {
            ICollection<Weight> Weights = await _WeightRepository.FilterAsync(x => x.IsActive && x.WeightId != 1059);
            List<SelectedModel> selectModels = Weights.Select(x => new SelectedModel 
            {
                Text = x.WeightName,
                Value = x.WeightId
            }).ToList();
            return selectModels;
        }
    }
}
