using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AllowancePercentages.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AllowancePercentages.Handlers.Queries
{
    public class GetSelectedAllowancePercentageRequestHandler : IRequestHandler<GetSelectedAllowancePercentageRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AllowancePercentage> _AllowancePercentageRepository;


        public GetSelectedAllowancePercentageRequestHandler(ISchoolManagementRepository<AllowancePercentage> AllowancePercentageRepository)
        {
            _AllowancePercentageRepository = AllowancePercentageRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAllowancePercentageRequest request, CancellationToken cancellationToken)
        {
            ICollection<AllowancePercentage> AllowancePercentages = await _AllowancePercentageRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = AllowancePercentages.Select(x => new SelectedModel 
            {
                Text = x.AllowanceName + "_"+x.Percentage,
                Value = x.AllowancePercentageId
            }).ToList();
            return selectModels;
        }
        
    }
}
