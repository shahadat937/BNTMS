using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.FinancialSanctions.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FinancialSanctions.Handlers.Queries
{
    public class GetSelectedFinancialSanctionRequestHandler : IRequestHandler<GetSelectedFinancialSanctionRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<FinancialSanction> _FinancialSanctionRepository;


        public GetSelectedFinancialSanctionRequestHandler(ISchoolManagementRepository<FinancialSanction> FinancialSanctionRepository)
        {
            _FinancialSanctionRepository = FinancialSanctionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedFinancialSanctionRequest request, CancellationToken cancellationToken)
        {
            ICollection<FinancialSanction> codeValues = await _FinancialSanctionRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.FinancialSanctionId
            }).ToList();
            return selectModels;
        }
    }
}
