using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MarkCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MarkCategorys.Handlers.Queries
{
    public class GetSelectedMarkCategoryRequestHandler : IRequestHandler<GetSelectedMarkCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MarkCategory> _MarkCategoryRepository;


        public GetSelectedMarkCategoryRequestHandler(ISchoolManagementRepository<MarkCategory> MarkCategoryRepository)
        {
            _MarkCategoryRepository = MarkCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMarkCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<MarkCategory> codeValues = await _MarkCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CategoryName,
                Value = x.MarkCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
