using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Heights.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Heights.Handlers.Queries
{ 
    public class GetSelectedHeightRequestHandler : IRequestHandler<GetSelectedHeightRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Height> _HeightRepository;


        public GetSelectedHeightRequestHandler(ISchoolManagementRepository<Height> HeightRepository)
        {
            _HeightRepository = HeightRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedHeightRequest request, CancellationToken cancellationToken)
        {
            ICollection<Height> Heights = await _HeightRepository.FilterAsync(x => x.IsActive && x.HeightId != 26);
            List<SelectedModel> selectModels = Heights.Select(x => new SelectedModel 
            {
                Text = x.HeightName,
                Value = x.HeightId
            }).ToList();
            return selectModels;
        }
    }
}
