using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BNASemesters.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Ranks.Handlers.Queries 
{ 
    public class GetSelectedRankRequestHandler : IRequestHandler<GetSelectedRankRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Rank> _RankRepository;


        public GetSelectedRankRequestHandler(ISchoolManagementRepository<Rank> RankRepository)
        {
            _RankRepository = RankRepository;
        }
         
        public async Task<List<SelectedModel>> Handle(GetSelectedRankRequest request, CancellationToken cancellationToken)
        {
            ICollection<Rank> Ranks = await _RankRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = Ranks.Select(x => new SelectedModel 
            {
                Text = x.RankName,
                Value = x.RankId
            }).ToList();
            return selectModels;
        }
    }
}
