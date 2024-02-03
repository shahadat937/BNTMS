using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.NewAtempts.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NewAtempts.Handlers.Queries
{
    public class GetSelectedNewAtemptRequestHandler : IRequestHandler<GetSelectedNewAtemptRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<NewAtempt> _NewAtemptRepository;


        public GetSelectedNewAtemptRequestHandler(ISchoolManagementRepository<NewAtempt> NewAtemptRepository)
        {
            _NewAtemptRepository = NewAtemptRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedNewAtemptRequest request, CancellationToken cancellationToken)
        {
            ICollection<NewAtempt> NewAtempts = await _NewAtemptRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = NewAtempts.Select(x => new SelectedModel 
            {
                Text = x.Name,
                Value = x.NewAtemptId
            }).ToList();
            return selectModels;
        }
    }
}
