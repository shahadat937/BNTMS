using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SaylorRanks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorRanks.Handlers.Queries
{
    public class GetSelectedSaylorRankRequestHandler : IRequestHandler<GetSelectedSaylorRankRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SaylorRank> _SaylorRankRepository;


        public GetSelectedSaylorRankRequestHandler(ISchoolManagementRepository<SaylorRank> SaylorRankRepository)
        {
            _SaylorRankRepository = SaylorRankRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSaylorRankRequest request, CancellationToken cancellationToken)
        {
            ICollection<SaylorRank> codeValues = await _SaylorRankRepository.FilterAsync(x => x.IsActive && x.SaylorRankId != 1011);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SaylorRankId
            }).ToList();
            return selectModels;
        }
    }
}
