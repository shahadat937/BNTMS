using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Handlers.Queries
{
    public class GetSelectedAllowanceCategoryRequestHandler : IRequestHandler<GetSelectedAllowanceCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AllowanceCategory> _AllowanceCategoryRepository;


        public GetSelectedAllowanceCategoryRequestHandler(ISchoolManagementRepository<AllowanceCategory> AllowanceCategoryRepository)
        {
            _AllowanceCategoryRepository = AllowanceCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAllowanceCategoryRequest request, CancellationToken cancellationToken)
        {
            //ICollection<AllowanceCategory> AllowanceCategorys = await _AllowanceCategoryRepository.FilterAsync(x => x.IsActive);
            //var AllowanceCategorys = await _AllowanceCategoryRepository.FilterWithInclude(x => x.IsActive, "AllowancePercentage");
            IQueryable<AllowanceCategory> AllowanceCategorys = _AllowanceCategoryRepository.FilterWithInclude(x => x.IsActive, "AllowancePercentage");
            List<SelectedModel> selectModels = AllowanceCategorys.Select(x => new SelectedModel 
            {
                Text = x.AllowancePercentage.AllowanceName,
                Value = x.AllowanceCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
