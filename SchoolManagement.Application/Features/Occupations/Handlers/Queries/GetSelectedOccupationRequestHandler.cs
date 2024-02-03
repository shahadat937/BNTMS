using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Occupations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Occupations.Handlers.Queries
{
    public class GetSelectedOccupationRequestHandler : IRequestHandler<GetSelectedOccupationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Occupation> _OccupationRepository;


        public GetSelectedOccupationRequestHandler(ISchoolManagementRepository<Occupation> OccupationRepository)
        {
            _OccupationRepository = OccupationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedOccupationRequest request, CancellationToken cancellationToken)
        {
            ICollection<Occupation> codeValues = await _OccupationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.OccupationName,
                Value = x.OccupationId
            }).ToList();
            return selectModels;
        }
    }
}
