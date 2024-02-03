using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Games.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Games.Handlers.Queries
{
    public class GetSelectedGameRequestHandler : IRequestHandler<GetSelectedGameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Game> _GameRepository;


        public GetSelectedGameRequestHandler(ISchoolManagementRepository<Game> GameRepository)
        {
            _GameRepository = GameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGameRequest request, CancellationToken cancellationToken)
        {
            ICollection<Game> codeValues = await _GameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.GameName,
                Value = x.GameId
            }).ToList();
            return selectModels;
        }
    }
}
